namespace ReadDPR_Winform
{
    partial class frmProgress
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
            this.components = new System.ComponentModel.Container();
            this.lblText = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(5, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(289, 23);
            this.lblText.TabIndex = 0;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(5, 37);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(289, 23);
            this.pb.TabIndex = 1;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 500;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // frmProgress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(299, 67);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProgress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProgress_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProgress_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Timer timerRefresh;
    }
}