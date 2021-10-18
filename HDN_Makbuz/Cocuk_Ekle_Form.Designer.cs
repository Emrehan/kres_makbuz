namespace HDN_Makbuz
{
    partial class Cocuk_Ekle_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_ad_soyad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_sinif = new System.Windows.Forms.Label();
            this.label_cinsiyet = new System.Windows.Forms.Label();
            this.label_aylik = new System.Windows.Forms.Label();
            this.label_gelme_duzeni = new System.Windows.Forms.Label();
            this.textBox_isim = new System.Windows.Forms.TextBox();
            this.textBox_tc = new System.Windows.Forms.TextBox();
            this.button_sinif = new System.Windows.Forms.Button();
            this.button_cinsiyet = new System.Windows.Forms.Button();
            this.textBox_gelme = new System.Windows.Forms.TextBox();
            this.button_ekle = new System.Windows.Forms.Button();
            this.numericUpDown_aylik = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_adres = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_aylik)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ad_soyad
            // 
            this.label_ad_soyad.AutoSize = true;
            this.label_ad_soyad.Location = new System.Drawing.Point(33, 13);
            this.label_ad_soyad.Name = "label_ad_soyad";
            this.label_ad_soyad.Size = new System.Drawing.Size(53, 13);
            this.label_ad_soyad.TabIndex = 0;
            this.label_ad_soyad.Text = "Ad Soyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TC";
            // 
            // label_sinif
            // 
            this.label_sinif.AutoSize = true;
            this.label_sinif.Location = new System.Drawing.Point(59, 173);
            this.label_sinif.Name = "label_sinif";
            this.label_sinif.Size = new System.Drawing.Size(27, 13);
            this.label_sinif.TabIndex = 2;
            this.label_sinif.Text = "Sınıf";
            // 
            // label_cinsiyet
            // 
            this.label_cinsiyet.AutoSize = true;
            this.label_cinsiyet.Location = new System.Drawing.Point(43, 200);
            this.label_cinsiyet.Name = "label_cinsiyet";
            this.label_cinsiyet.Size = new System.Drawing.Size(43, 13);
            this.label_cinsiyet.TabIndex = 3;
            this.label_cinsiyet.Text = "Cinsiyet";
            // 
            // label_aylik
            // 
            this.label_aylik.AutoSize = true;
            this.label_aylik.Location = new System.Drawing.Point(28, 228);
            this.label_aylik.Name = "label_aylik";
            this.label_aylik.Size = new System.Drawing.Size(58, 13);
            this.label_aylik.TabIndex = 4;
            this.label_aylik.Text = "Aylık Ücret";
            // 
            // label_gelme_duzeni
            // 
            this.label_gelme_duzeni.AutoSize = true;
            this.label_gelme_duzeni.Location = new System.Drawing.Point(13, 257);
            this.label_gelme_duzeni.Name = "label_gelme_duzeni";
            this.label_gelme_duzeni.Size = new System.Drawing.Size(73, 13);
            this.label_gelme_duzeni.TabIndex = 5;
            this.label_gelme_duzeni.Text = "Gelme Düzeni";
            // 
            // textBox_isim
            // 
            this.textBox_isim.Location = new System.Drawing.Point(92, 10);
            this.textBox_isim.Name = "textBox_isim";
            this.textBox_isim.Size = new System.Drawing.Size(100, 20);
            this.textBox_isim.TabIndex = 6;
            // 
            // textBox_tc
            // 
            this.textBox_tc.Location = new System.Drawing.Point(92, 143);
            this.textBox_tc.Name = "textBox_tc";
            this.textBox_tc.Size = new System.Drawing.Size(100, 20);
            this.textBox_tc.TabIndex = 7;
            // 
            // button_sinif
            // 
            this.button_sinif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sinif.Location = new System.Drawing.Point(92, 167);
            this.button_sinif.Name = "button_sinif";
            this.button_sinif.Size = new System.Drawing.Size(100, 24);
            this.button_sinif.TabIndex = 12;
            this.button_sinif.UseVisualStyleBackColor = true;
            this.button_sinif.Click += new System.EventHandler(this.button_sinif_Click);
            // 
            // button_cinsiyet
            // 
            this.button_cinsiyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cinsiyet.Location = new System.Drawing.Point(92, 194);
            this.button_cinsiyet.Name = "button_cinsiyet";
            this.button_cinsiyet.Size = new System.Drawing.Size(100, 24);
            this.button_cinsiyet.TabIndex = 13;
            this.button_cinsiyet.UseVisualStyleBackColor = true;
            this.button_cinsiyet.Click += new System.EventHandler(this.button_cinsiyet_Click);
            // 
            // textBox_gelme
            // 
            this.textBox_gelme.Location = new System.Drawing.Point(92, 253);
            this.textBox_gelme.Name = "textBox_gelme";
            this.textBox_gelme.Size = new System.Drawing.Size(100, 20);
            this.textBox_gelme.TabIndex = 14;
            // 
            // button_ekle
            // 
            this.button_ekle.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ekle.Location = new System.Drawing.Point(46, 289);
            this.button_ekle.Name = "button_ekle";
            this.button_ekle.Size = new System.Drawing.Size(100, 24);
            this.button_ekle.TabIndex = 15;
            this.button_ekle.Text = "Ekle";
            this.button_ekle.UseVisualStyleBackColor = true;
            this.button_ekle.Click += new System.EventHandler(this.button_ekle_Click);
            // 
            // numericUpDown_aylik
            // 
            this.numericUpDown_aylik.DecimalPlaces = 2;
            this.numericUpDown_aylik.Location = new System.Drawing.Point(92, 224);
            this.numericUpDown_aylik.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_aylik.Name = "numericUpDown_aylik";
            this.numericUpDown_aylik.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown_aylik.TabIndex = 16;
            this.numericUpDown_aylik.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Adres";
            // 
            // richTextBox_adres
            // 
            this.richTextBox_adres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_adres.Location = new System.Drawing.Point(92, 39);
            this.richTextBox_adres.Name = "richTextBox_adres";
            this.richTextBox_adres.Size = new System.Drawing.Size(100, 96);
            this.richTextBox_adres.TabIndex = 18;
            this.richTextBox_adres.Text = "";
            // 
            // Cocuk_Ekle_Form
            // 
            this.AcceptButton = this.button_ekle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(214, 319);
            this.Controls.Add(this.richTextBox_adres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_aylik);
            this.Controls.Add(this.button_ekle);
            this.Controls.Add(this.textBox_gelme);
            this.Controls.Add(this.button_cinsiyet);
            this.Controls.Add(this.button_sinif);
            this.Controls.Add(this.textBox_tc);
            this.Controls.Add(this.textBox_isim);
            this.Controls.Add(this.label_gelme_duzeni);
            this.Controls.Add(this.label_aylik);
            this.Controls.Add(this.label_cinsiyet);
            this.Controls.Add(this.label_sinif);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_ad_soyad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Cocuk_Ekle_Form";
            this.Text = "Çocuk Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_aylik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ad_soyad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_sinif;
        private System.Windows.Forms.Label label_cinsiyet;
        private System.Windows.Forms.Label label_aylik;
        private System.Windows.Forms.Label label_gelme_duzeni;
        private System.Windows.Forms.TextBox textBox_isim;
        private System.Windows.Forms.TextBox textBox_tc;
        private System.Windows.Forms.Button button_sinif;
        private System.Windows.Forms.Button button_cinsiyet;
        private System.Windows.Forms.TextBox textBox_gelme;
        private System.Windows.Forms.Button button_ekle;
        private System.Windows.Forms.NumericUpDown numericUpDown_aylik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_adres;
    }
}