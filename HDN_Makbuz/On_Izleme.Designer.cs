namespace HDN_Makbuz
{
    partial class On_Izleme
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
            this.button_tamam = new System.Windows.Forms.Button();
            this.button_iptal = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button_tamam
            // 
            this.button_tamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_tamam.Location = new System.Drawing.Point(359, 502);
            this.button_tamam.Name = "button_tamam";
            this.button_tamam.Size = new System.Drawing.Size(75, 47);
            this.button_tamam.TabIndex = 0;
            this.button_tamam.Text = "Tamam";
            this.button_tamam.UseVisualStyleBackColor = true;
            // 
            // button_iptal
            // 
            this.button_iptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_iptal.Location = new System.Drawing.Point(440, 502);
            this.button_iptal.Name = "button_iptal";
            this.button_iptal.Size = new System.Drawing.Size(75, 47);
            this.button_iptal.TabIndex = 1;
            this.button_iptal.Text = "İptal";
            this.button_iptal.UseVisualStyleBackColor = true;
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(584, 749);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // On_Izleme
            // 
            this.AcceptButton = this.button_tamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_iptal;
            this.ClientSize = new System.Drawing.Size(584, 749);
            this.Controls.Add(this.button_iptal);
            this.Controls.Add(this.button_tamam);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "On_Izleme";
            this.Text = "On_Izleme";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_tamam;
        private System.Windows.Forms.Button button_iptal;
        public System.Windows.Forms.PictureBox pictureBox;
    }
}