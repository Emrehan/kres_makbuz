namespace HDN_Makbuz
{
    partial class Text_Degistir
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
            this.textBox_eski = new System.Windows.Forms.TextBox();
            this.textBox_yeni = new System.Windows.Forms.TextBox();
            this.label_eski = new System.Windows.Forms.Label();
            this.label_yeni = new System.Windows.Forms.Label();
            this.button_onayla = new System.Windows.Forms.Button();
            this.button_vazgec = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_eski
            // 
            this.textBox_eski.Enabled = false;
            this.textBox_eski.Location = new System.Drawing.Point(58, 26);
            this.textBox_eski.Name = "textBox_eski";
            this.textBox_eski.Size = new System.Drawing.Size(178, 20);
            this.textBox_eski.TabIndex = 0;
            // 
            // textBox_yeni
            // 
            this.textBox_yeni.Location = new System.Drawing.Point(58, 52);
            this.textBox_yeni.Name = "textBox_yeni";
            this.textBox_yeni.Size = new System.Drawing.Size(178, 20);
            this.textBox_yeni.TabIndex = 1;
            this.textBox_yeni.TextChanged += new System.EventHandler(this.textBox_yeni_TextChanged);
            this.textBox_yeni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_yeni_KeyPress);
            // 
            // label_eski
            // 
            this.label_eski.AutoSize = true;
            this.label_eski.Location = new System.Drawing.Point(13, 30);
            this.label_eski.Name = "label_eski";
            this.label_eski.Size = new System.Drawing.Size(27, 13);
            this.label_eski.TabIndex = 2;
            this.label_eski.Text = "Eski";
            // 
            // label_yeni
            // 
            this.label_yeni.AutoSize = true;
            this.label_yeni.Location = new System.Drawing.Point(12, 56);
            this.label_yeni.Name = "label_yeni";
            this.label_yeni.Size = new System.Drawing.Size(28, 13);
            this.label_yeni.TabIndex = 3;
            this.label_yeni.Text = "Yeni";
            // 
            // button_onayla
            // 
            this.button_onayla.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_onayla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_onayla.ForeColor = System.Drawing.Color.DarkGreen;
            this.button_onayla.Location = new System.Drawing.Point(58, 97);
            this.button_onayla.Name = "button_onayla";
            this.button_onayla.Size = new System.Drawing.Size(75, 23);
            this.button_onayla.TabIndex = 4;
            this.button_onayla.Text = "Onayla";
            this.button_onayla.UseVisualStyleBackColor = true;
            this.button_onayla.Click += new System.EventHandler(this.button_onayla_Click);
            // 
            // button_vazgec
            // 
            this.button_vazgec.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_vazgec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_vazgec.ForeColor = System.Drawing.Color.Crimson;
            this.button_vazgec.Location = new System.Drawing.Point(161, 97);
            this.button_vazgec.Name = "button_vazgec";
            this.button_vazgec.Size = new System.Drawing.Size(75, 23);
            this.button_vazgec.TabIndex = 5;
            this.button_vazgec.Text = "Vazgeç";
            this.button_vazgec.UseVisualStyleBackColor = true;
            // 
            // Text_Degistir
            // 
            this.AcceptButton = this.button_onayla;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_vazgec;
            this.ClientSize = new System.Drawing.Size(265, 145);
            this.Controls.Add(this.button_vazgec);
            this.Controls.Add(this.button_onayla);
            this.Controls.Add(this.label_yeni);
            this.Controls.Add(this.label_eski);
            this.Controls.Add(this.textBox_yeni);
            this.Controls.Add(this.textBox_eski);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Text_Degistir";
            this.Text = "Değer Değiştir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_eski;
        private System.Windows.Forms.Label label_yeni;
        private System.Windows.Forms.Button button_onayla;
        private System.Windows.Forms.Button button_vazgec;
        public System.Windows.Forms.TextBox textBox_eski;
        public System.Windows.Forms.TextBox textBox_yeni;
    }
}