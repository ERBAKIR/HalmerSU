using MaterialSkin;
using MetroFramework;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using System.Windows.Forms;

namespace HalmerSuTuketim
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            bitisDateTime.Value = DateTime.Today;
            bitisDateTime.Enabled = false; // kullanıcı değiştiremesin
            this.Style = MetroColorStyle.Orange;
            metroButton1.StyleManager = null;

            try
            {
                var bolgeGetir = DbHelper.DataGetir("SELECT id,description FROM halmer_meter_prod.meter_entity where meter_type = 'WATER';");

                foreach (DataRow row in bolgeGetir.Rows)
                {
                    var id = row["id"].ToString();
                    var desc = row["description"].ToString();

                    materialComboBox1.Items.Add(new ComboBoxItem
                    {
                        Text = desc,
                        Value = id
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabaný baðlantýsý baþarýsýz: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DateTime baslangic = baslangicDateTime.Value.Date;  // 00:00:00
            //DateTime bitis = bitisDateTime.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59); ÖNCEKKİ HALİ
            DateTime bitis = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59);

            decimal toplamTuketim;

            if (!decimal.TryParse(txtTuketim.Text, out toplamTuketim))
            {
                MessageBox.Show("Lütfen geçerli bir sayý giriniz!",
                                "Hatalý Giriþ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            
            if (bitis < baslangic)
            {
                MessageBox.Show("Bitiþ tarihi, baþlangýç tarihinden önce olamaz!", "Tarih Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (materialComboBox1.SelectedItem is ComboBoxItem selectedItem)
            {
                string secilenText = selectedItem.Text;
                string secilenValue = selectedItem.Value;

                MessageBox.Show($"Seçilen: {secilenText} - {secilenValue}");

                string query = @"
                            INSERT INTO halmer_meter_prod.meter_data_entity_log
                            (
                                id,
                                meter_entity_id,
                                created_at,
                                updated_at,
                                data,
                                month,
                                year
                            )
                            SELECT
                                id,
                                meter_entity_id,
                                created_at,
                                updated_at,
                                data,
                                month,
                                year
                            FROM halmer_meter_prod.meter_data_entity
                            WHERE meter_entity_id = @meterId
                              AND created_at BETWEEN @startDate AND @endDate;";

                int inserted = DbHelper.Execute(query,
                    new MySqlParameter("@meterId", MySqlDbType.VarChar) { Value = secilenValue },
                    new MySqlParameter("@startDate", MySqlDbType.DateTime) { Value = baslangic },
                    new MySqlParameter("@endDate", MySqlDbType.DateTime) { Value = bitis }
                );

                MessageBox.Show($"{inserted} kayit log tablosuna eklendi.");

                string sql = @"
                            WITH base AS (
                                SELECT
                                    id,
                                    ROW_NUMBER() OVER (ORDER BY created_at, id) - 1 AS rn,
                                    COUNT(*)    OVER () AS totalRows,
                                    FIRST_VALUE(data) OVER (ORDER BY created_at, id) AS first_old
                                FROM halmer_meter_prod.meter_data_entity
                                WHERE meter_entity_id = @meterId
                                  AND created_at >= @startDate
                                  AND created_at <  @endDate
                            ),
                            calc AS (
                                SELECT
                                    id,
                                    (first_old + (CAST(@toplamTuketim AS DECIMAL(18,6)) / NULLIF(totalRows, 0)) * rn) AS new_data
                                FROM base
                            )
                            UPDATE halmer_meter_prod.meter_data_entity AS t
                            JOIN calc ON t.id = calc.id
                            SET t.data = calc.new_data;";

                try
                {
                    int affected = DbHelper.Execute(
                        sql,
                        new MySql.Data.MySqlClient.MySqlParameter("@meterId", MySql.Data.MySqlClient.MySqlDbType.VarChar) { Value = secilenValue },
                        new MySql.Data.MySqlClient.MySqlParameter("@startDate", MySql.Data.MySqlClient.MySqlDbType.DateTime) { Value = baslangic },
                        new MySql.Data.MySqlClient.MySqlParameter("@endDate", MySql.Data.MySqlClient.MySqlDbType.DateTime) { Value = bitis },
                        new MySql.Data.MySqlClient.MySqlParameter("@toplamTuketim", MySql.Data.MySqlClient.MySqlDbType.Decimal) { Value = toplamTuketim }
                    );

                    MessageBox.Show($"{affected} satýr güncellendi.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sýrasýnda hata oluþtu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                string updateLastDataSql = @"
                                        UPDATE halmer_meter_prod.meter_entity AS me
                                                SET me.last_data = (
                                                                SELECT t.data FROM (
                                                        SELECT mde.data
                                                        FROM halmer_meter_prod.meter_data_entity AS mde
                                                        WHERE mde.meter_entity_id = @meterId
                                                          AND mde.created_at >= @startDate
                                                          AND mde.created_at <= @endDate
                                                        ORDER BY mde.created_at DESC, mde.id DESC
                                                        LIMIT 1
                                                    ) AS t
                                                )
                                                WHERE me.id = @meterId;";

                int lastUpd = DbHelper.Execute(
                    updateLastDataSql,
                    new MySql.Data.MySqlClient.MySqlParameter("@meterId", MySql.Data.MySqlClient.MySqlDbType.VarChar) { Value = secilenValue },
                    new MySql.Data.MySqlClient.MySqlParameter("@startDate", MySql.Data.MySqlClient.MySqlDbType.DateTime) { Value = baslangic },
                    new MySql.Data.MySqlClient.MySqlParameter("@endDate", MySql.Data.MySqlClient.MySqlDbType.DateTime) { Value = bitis }
                );

                MessageBox.Show("Veriler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //MessageBox.Show("Veriler güncellenemedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void poisonDateTime2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTuketim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void materialListBox1_SelectedIndexChanged(object sender, ReaLTaiizor.Child.Material.MaterialListBoxItem selectedItem)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
