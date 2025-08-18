using MetroFramework;
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
            this.Style = MetroColorStyle.Orange;
            metroButton1.StyleManager = null;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DateTime baslangic = baslangicDateTime.Value;
            DateTime bitis = bitisDateTime.Value;

            if (bitis < baslangic)
            {
                MessageBox.Show("Bitiþ tarihi, baþlangýç tarihinden önce olamaz!", "Tarih Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Veriler güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
