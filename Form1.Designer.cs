namespace HalmerSuTuketim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            baslangicDateTime = new ReaLTaiizor.Controls.PoisonDateTime();
            materialLabel1 = new ReaLTaiizor.Controls.MaterialLabel();
            materialLabel2 = new ReaLTaiizor.Controls.MaterialLabel();
            bitisDateTime = new ReaLTaiizor.Controls.PoisonDateTime();
            materialLabel3 = new ReaLTaiizor.Controls.MaterialLabel();
            txtTuketim = new TextBox();
            metroButton1 = new ReaLTaiizor.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(299, 246);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 94);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Location = new Point(-1, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(1000, 1);
            panel1.TabIndex = 2;
            // 
            // baslangicDateTime
            // 
            baslangicDateTime.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            baslangicDateTime.Location = new Point(149, 82);
            baslangicDateTime.MinimumSize = new Size(0, 29);
            baslangicDateTime.Name = "baslangicDateTime";
            baslangicDateTime.Size = new Size(200, 29);
            baslangicDateTime.TabIndex = 3;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(23, 87);
            materialLabel1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(120, 19);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "Başlangıç Tarihi:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(23, 133);
            materialLabel2.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(81, 19);
            materialLabel2.TabIndex = 6;
            materialLabel2.Text = "Bitiş Tarihi:";
            // 
            // bitisDateTime
            // 
            bitisDateTime.FontSize = ReaLTaiizor.Extension.Poison.PoisonDateTimeSize.Medium;
            bitisDateTime.Location = new Point(149, 128);
            bitisDateTime.MinimumSize = new Size(0, 29);
            bitisDateTime.Name = "bitisDateTime";
            bitisDateTime.Size = new Size(200, 29);
            bitisDateTime.TabIndex = 5;
            bitisDateTime.ValueChanged += poisonDateTime2_ValueChanged;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(23, 183);
            materialLabel3.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(122, 19);
            materialLabel3.TabIndex = 7;
            materialLabel3.Text = "Toplam Tüketim:";
            // 
            // txtTuketim
            // 
            txtTuketim.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtTuketim.Location = new Point(149, 173);
            txtTuketim.Name = "txtTuketim";
            txtTuketim.Size = new Size(200, 29);
            txtTuketim.TabIndex = 9;
            txtTuketim.TextAlign = HorizontalAlignment.Center;
            txtTuketim.KeyPress += txtTuketim_KeyPress;
            // 
            // metroButton1
            // 
            metroButton1.DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
            metroButton1.DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
            metroButton1.DisabledForeColor = Color.Gray;
            metroButton1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            metroButton1.ForeColor = SystemColors.HighlightText;
            metroButton1.HoverBorderColor = Color.FromArgb(95, 207, 255);
            metroButton1.HoverColor = Color.FromArgb(95, 207, 255);
            metroButton1.HoverTextColor = Color.White;
            metroButton1.IsDerivedStyle = true;
            metroButton1.Location = new Point(23, 231);
            metroButton1.Name = "metroButton1";
            metroButton1.NormalBorderColor = Color.FromArgb(65, 177, 225);
            metroButton1.NormalColor = Color.DarkSalmon;
            metroButton1.NormalTextColor = Color.Black;
            metroButton1.PressBorderColor = Color.FromArgb(35, 147, 195);
            metroButton1.PressColor = Color.FromArgb(35, 147, 195);
            metroButton1.PressTextColor = Color.White;
            metroButton1.Size = new Size(161, 39);
            metroButton1.Style = ReaLTaiizor.Enum.Metro.Style.Light;
            metroButton1.StyleManager = null;
            metroButton1.TabIndex = 12;
            metroButton1.Text = "Verileri Güncelle";
            metroButton1.ThemeAuthor = "Taiizor";
            metroButton1.ThemeName = "MetroLight";
            metroButton1.Click += btnGuncelle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 338);
            Controls.Add(metroButton1);
            Controls.Add(txtTuketim);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(bitisDateTime);
            Controls.Add(materialLabel1);
            Controls.Add(baslangicDateTime);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ActiveCaption;
            MaximizeBox = false;
            MaximumSize = new Size(1920, 1032);
            MinimumSize = new Size(261, 81);
            Name = "Form1";
            Resizable = false;
            ShowIcon = false;
            Text = "Halmer Su Tüketim";
            Theme = MetroFramework.MetroThemeStyle.Light;
            TransparencyKey = Color.Fuchsia;
            Load += Form1Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private ReaLTaiizor.Controls.PoisonDateTime baslangicDateTime;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel1;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel2;
        private ReaLTaiizor.Controls.PoisonDateTime bitisDateTime;
        private ReaLTaiizor.Controls.MaterialLabel materialLabel3;
        private TextBox txtTuketim;
        private ReaLTaiizor.Controls.MetroButton metroButton1;
    }
}
