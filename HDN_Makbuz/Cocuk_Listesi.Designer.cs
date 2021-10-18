namespace HDN_Makbuz
{
    partial class Cocuk_Listesi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_tamamlandi = new System.Windows.Forms.Button();
            this.button_cocuk_ekle = new System.Windows.Forms.Button();
            this.Column_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_cocuk_adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_adres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_tc_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_duzen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_aylik_ucret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_aylik_kdvsiz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_odenen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_sinif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_cinsiyet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_aktif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_sec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox_devam_goster = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_id,
            this.Column_cocuk_adi,
            this.Column_adres,
            this.Column_tc_no,
            this.Column_duzen,
            this.Column_aylik_ucret,
            this.Column_aylik_kdvsiz,
            this.Column_odenen,
            this.Column_sinif,
            this.Column_cinsiyet,
            this.Column_aktif,
            this.Column_sec});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1085, 305);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_tamamlandi
            // 
            this.button_tamamlandi.BackColor = System.Drawing.Color.White;
            this.button_tamamlandi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_tamamlandi.ForeColor = System.Drawing.Color.Black;
            this.button_tamamlandi.Location = new System.Drawing.Point(3, 3);
            this.button_tamamlandi.Name = "button_tamamlandi";
            this.button_tamamlandi.Size = new System.Drawing.Size(75, 23);
            this.button_tamamlandi.TabIndex = 5;
            this.button_tamamlandi.Text = "Tamam";
            this.button_tamamlandi.UseVisualStyleBackColor = false;
            this.button_tamamlandi.Click += new System.EventHandler(this.button_tamamlandi_Click);
            // 
            // button_cocuk_ekle
            // 
            this.button_cocuk_ekle.BackColor = System.Drawing.Color.White;
            this.button_cocuk_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cocuk_ekle.ForeColor = System.Drawing.Color.Black;
            this.button_cocuk_ekle.Location = new System.Drawing.Point(3, 32);
            this.button_cocuk_ekle.Name = "button_cocuk_ekle";
            this.button_cocuk_ekle.Size = new System.Drawing.Size(75, 23);
            this.button_cocuk_ekle.TabIndex = 6;
            this.button_cocuk_ekle.Text = "Çocuk Ekle";
            this.button_cocuk_ekle.UseVisualStyleBackColor = false;
            this.button_cocuk_ekle.Click += new System.EventHandler(this.button_cocuk_ekle_Click);
            // 
            // Column_id
            // 
            this.Column_id.FillWeight = 1F;
            this.Column_id.Frozen = true;
            this.Column_id.HeaderText = "ID";
            this.Column_id.Name = "Column_id";
            this.Column_id.ReadOnly = true;
            this.Column_id.Width = 5;
            // 
            // Column_cocuk_adi
            // 
            this.Column_cocuk_adi.Frozen = true;
            this.Column_cocuk_adi.HeaderText = "Ad Soyad";
            this.Column_cocuk_adi.Name = "Column_cocuk_adi";
            this.Column_cocuk_adi.Width = 200;
            // 
            // Column_adres
            // 
            this.Column_adres.HeaderText = "Adres";
            this.Column_adres.Name = "Column_adres";
            this.Column_adres.Width = 120;
            // 
            // Column_tc_no
            // 
            this.Column_tc_no.HeaderText = "TC No";
            this.Column_tc_no.Name = "Column_tc_no";
            // 
            // Column_duzen
            // 
            this.Column_duzen.HeaderText = "Gelme Düzeni";
            this.Column_duzen.Name = "Column_duzen";
            // 
            // Column_aylik_ucret
            // 
            this.Column_aylik_ucret.HeaderText = "Aylık Ücret";
            this.Column_aylik_ucret.Name = "Column_aylik_ucret";
            this.Column_aylik_ucret.Width = 60;
            // 
            // Column_aylik_kdvsiz
            // 
            this.Column_aylik_kdvsiz.HeaderText = "KDVsiz";
            this.Column_aylik_kdvsiz.Name = "Column_aylik_kdvsiz";
            this.Column_aylik_kdvsiz.ReadOnly = true;
            this.Column_aylik_kdvsiz.Width = 60;
            // 
            // Column_odenen
            // 
            this.Column_odenen.HeaderText = "KDV";
            this.Column_odenen.Name = "Column_odenen";
            this.Column_odenen.ReadOnly = true;
            this.Column_odenen.Width = 60;
            // 
            // Column_sinif
            // 
            this.Column_sinif.HeaderText = "Sınıf";
            this.Column_sinif.Name = "Column_sinif";
            this.Column_sinif.ReadOnly = true;
            this.Column_sinif.Width = 80;
            // 
            // Column_cinsiyet
            // 
            this.Column_cinsiyet.HeaderText = "Cinsiyet";
            this.Column_cinsiyet.Name = "Column_cinsiyet";
            this.Column_cinsiyet.ReadOnly = true;
            this.Column_cinsiyet.Width = 60;
            // 
            // Column_aktif
            // 
            this.Column_aktif.HeaderText = "Devam Ediyor";
            this.Column_aktif.Name = "Column_aktif";
            this.Column_aktif.ReadOnly = true;
            this.Column_aktif.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_aktif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_aktif.Width = 60;
            // 
            // Column_sec
            // 
            this.Column_sec.HeaderText = "Seç";
            this.Column_sec.Name = "Column_sec";
            this.Column_sec.ReadOnly = true;
            this.Column_sec.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_sec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_sec.Width = 60;
            // 
            // checkBox_devam_goster
            // 
            this.checkBox_devam_goster.Location = new System.Drawing.Point(3, 61);
            this.checkBox_devam_goster.Name = "checkBox_devam_goster";
            this.checkBox_devam_goster.Size = new System.Drawing.Size(104, 46);
            this.checkBox_devam_goster.TabIndex = 7;
            this.checkBox_devam_goster.Text = "Devam Etmeyenleri Göster";
            this.checkBox_devam_goster.UseVisualStyleBackColor = true;
            this.checkBox_devam_goster.CheckedChanged += new System.EventHandler(this.checkBox_devam_goster_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_tamamlandi);
            this.panel1.Controls.Add(this.checkBox_devam_goster);
            this.panel1.Controls.Add(this.button_cocuk_ekle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1007, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 305);
            this.panel1.TabIndex = 8;
            // 
            // Cocuk_Listesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Cocuk_Listesi";
            this.Size = new System.Drawing.Size(1085, 305);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_tamamlandi;
        private System.Windows.Forms.Button button_cocuk_ekle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_cocuk_adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_adres;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_tc_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_duzen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_aylik_ucret;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_aylik_kdvsiz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_odenen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_sinif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_cinsiyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_aktif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_sec;
        private System.Windows.Forms.CheckBox checkBox_devam_goster;
        private System.Windows.Forms.Panel panel1;
    }
}
