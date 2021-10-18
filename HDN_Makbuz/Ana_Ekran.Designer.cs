namespace HDN_Makbuz
{
    partial class Ana_Ekran
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label_versiyon = new System.Windows.Forms.Label();
            this.button_cocuk_sec = new System.Windows.Forms.Button();
            this.dateTimePicker_tarih = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label_kdv = new System.Windows.Forms.Label();
            this.label_cocuk_sayisi = new System.Windows.Forms.Label();
            this.button_yazdir = new System.Windows.Forms.Button();
            this.cocuk_Listesi = new HDN_Makbuz.Cocuk_Listesi();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackgroundImage = global::HDN_Makbuz.Properties.Resources._5_Fantastic_Boredom_Busters_Image_2_682x1024;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(856, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 325);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox2.BackgroundImage = global::HDN_Makbuz.Properties.Resources.kres_logo_HQ;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(906, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(167, 77);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label_versiyon
            // 
            this.label_versiyon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_versiyon.AutoSize = true;
            this.label_versiyon.Location = new System.Drawing.Point(1045, 408);
            this.label_versiyon.Name = "label_versiyon";
            this.label_versiyon.Size = new System.Drawing.Size(31, 13);
            this.label_versiyon.TabIndex = 2;
            this.label_versiyon.Text = "0.0.0";
            // 
            // button_cocuk_sec
            // 
            this.button_cocuk_sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_cocuk_sec.Location = new System.Drawing.Point(203, 91);
            this.button_cocuk_sec.Name = "button_cocuk_sec";
            this.button_cocuk_sec.Size = new System.Drawing.Size(107, 72);
            this.button_cocuk_sec.TabIndex = 4;
            this.button_cocuk_sec.Text = "Çocuk Seç";
            this.button_cocuk_sec.UseVisualStyleBackColor = true;
            this.button_cocuk_sec.Click += new System.EventHandler(this.button_cocuk_sec_Click);
            // 
            // dateTimePicker_tarih
            // 
            this.dateTimePicker_tarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_tarih.Location = new System.Drawing.Point(203, 170);
            this.dateTimePicker_tarih.Name = "dateTimePicker_tarih";
            this.dateTimePicker_tarih.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker_tarih.TabIndex = 11;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(271, 196);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 20);
            this.numericUpDown1.TabIndex = 13;
            this.numericUpDown1.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label_kdv
            // 
            this.label_kdv.AutoSize = true;
            this.label_kdv.BackColor = System.Drawing.Color.White;
            this.label_kdv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_kdv.Location = new System.Drawing.Point(216, 198);
            this.label_kdv.Name = "label_kdv";
            this.label_kdv.Size = new System.Drawing.Size(43, 13);
            this.label_kdv.TabIndex = 12;
            this.label_kdv.Text = "KDV  %";
            // 
            // label_cocuk_sayisi
            // 
            this.label_cocuk_sayisi.AutoSize = true;
            this.label_cocuk_sayisi.Location = new System.Drawing.Point(216, 63);
            this.label_cocuk_sayisi.Name = "label_cocuk_sayisi";
            this.label_cocuk_sayisi.Size = new System.Drawing.Size(0, 13);
            this.label_cocuk_sayisi.TabIndex = 14;
            // 
            // button_yazdir
            // 
            this.button_yazdir.Enabled = false;
            this.button_yazdir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_yazdir.Location = new System.Drawing.Point(336, 91);
            this.button_yazdir.Name = "button_yazdir";
            this.button_yazdir.Size = new System.Drawing.Size(107, 72);
            this.button_yazdir.TabIndex = 15;
            this.button_yazdir.Text = "Yazdır";
            this.button_yazdir.UseVisualStyleBackColor = true;
            this.button_yazdir.Click += new System.EventHandler(this.button_yazdir_Click);
            // 
            // cocuk_Listesi
            // 
            this.cocuk_Listesi.Location = new System.Drawing.Point(12, 313);
            this.cocuk_Listesi.Name = "cocuk_Listesi";
            this.cocuk_Listesi.Size = new System.Drawing.Size(1085, 305);
            this.cocuk_Listesi.TabIndex = 3;
            this.cocuk_Listesi.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Ana_Ekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1085, 423);
            this.Controls.Add(this.button_yazdir);
            this.Controls.Add(this.label_cocuk_sayisi);
            this.Controls.Add(this.cocuk_Listesi);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label_kdv);
            this.Controls.Add(this.dateTimePicker_tarih);
            this.Controls.Add(this.button_cocuk_sec);
            this.Controls.Add(this.label_versiyon);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "Ana_Ekran";
            this.Text = "Makbuz - Harikalar Diyarı Neslihan Kreş ve Gündüz Bakımevi";
            this.Load += new System.EventHandler(this.Ana_Ekran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label_versiyon;
        private System.Windows.Forms.Button button_cocuk_sec;
        private Cocuk_Listesi cocuk_Listesi;
        private System.Windows.Forms.DateTimePicker dateTimePicker_tarih;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label_kdv;
        private System.Windows.Forms.Label label_cocuk_sayisi;
        private System.Windows.Forms.Button button_yazdir;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}