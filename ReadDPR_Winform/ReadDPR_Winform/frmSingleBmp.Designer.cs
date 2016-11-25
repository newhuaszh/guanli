namespace ReadDPR_Winform
{
    partial class frmSingleBmp
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
            this.flpWp = new System.Windows.Forms.FlowLayoutPanel();
            this.pbShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // flpWp
            // 
            this.flpWp.BackColor = System.Drawing.Color.LightGray;
            this.flpWp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpWp.Location = new System.Drawing.Point(0, 472);
            this.flpWp.Name = "flpWp";
            this.flpWp.Size = new System.Drawing.Size(578, 72);
            this.flpWp.TabIndex = 12;
            // 
            // pbShow
            // 
            this.pbShow.BackColor = System.Drawing.Color.Black;
            this.pbShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbShow.Location = new System.Drawing.Point(0, 0);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(578, 472);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShow.TabIndex = 13;
            this.pbShow.TabStop = false;
            // 
            // frmSingleBmp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(578, 544);
            this.Controls.Add(this.pbShow);
            this.Controls.Add(this.flpWp);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "frmSingleBmp";
            this.ShowIcon = false;
            this.Text = "frmSingleBmp";
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel flpWp;
        public System.Windows.Forms.PictureBox pbShow;
    }
}