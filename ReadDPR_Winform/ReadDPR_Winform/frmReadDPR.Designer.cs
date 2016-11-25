namespace ReadDPR_Winform
{
    partial class frmReadDPR
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnLayerUp = new System.Windows.Forms.Button();
            this.btnLayerDown = new System.Windows.Forms.Button();
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.btnShowDBZ = new System.Windows.Forms.Button();
            this.btnShowSW = new System.Windows.Forms.Button();
            this.btnShowRHO = new System.Windows.Forms.Button();
            this.btnShowKDP = new System.Windows.Forms.Button();
            this.btnShowVEL = new System.Windows.Forms.Button();
            this.btnShowZDR = new System.Windows.Forms.Button();
            this.btnShowPHI = new System.Windows.Forms.Button();
            this.flpWp = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(2, 2);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "OpenFile";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLayerUp
            // 
            this.btnLayerUp.Location = new System.Drawing.Point(86, 2);
            this.btnLayerUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLayerUp.Name = "btnLayerUp";
            this.btnLayerUp.Size = new System.Drawing.Size(80, 30);
            this.btnLayerUp.TabIndex = 1;
            this.btnLayerUp.Text = "LayerUp";
            this.btnLayerUp.UseVisualStyleBackColor = true;
            this.btnLayerUp.Click += new System.EventHandler(this.btnLayerUp_Click);
            // 
            // btnLayerDown
            // 
            this.btnLayerDown.Location = new System.Drawing.Point(170, 2);
            this.btnLayerDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLayerDown.Name = "btnLayerDown";
            this.btnLayerDown.Size = new System.Drawing.Size(80, 30);
            this.btnLayerDown.TabIndex = 2;
            this.btnLayerDown.Text = "LayerDown";
            this.btnLayerDown.UseVisualStyleBackColor = true;
            this.btnLayerDown.Click += new System.EventHandler(this.btnLayerDown_Click);
            // 
            // pbShow
            // 
            this.pbShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbShow.BackColor = System.Drawing.Color.Black;
            this.pbShow.Location = new System.Drawing.Point(2, 36);
            this.pbShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(397, 308);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShow.TabIndex = 3;
            this.pbShow.TabStop = false;
            // 
            // btnShowDBZ
            // 
            this.btnShowDBZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowDBZ.Location = new System.Drawing.Point(403, 36);
            this.btnShowDBZ.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowDBZ.Name = "btnShowDBZ";
            this.btnShowDBZ.Size = new System.Drawing.Size(80, 30);
            this.btnShowDBZ.TabIndex = 4;
            this.btnShowDBZ.Text = "DBZ";
            this.btnShowDBZ.UseVisualStyleBackColor = true;
            this.btnShowDBZ.Click += new System.EventHandler(this.btnShowDBZ_Click);
            // 
            // btnShowSW
            // 
            this.btnShowSW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowSW.Location = new System.Drawing.Point(403, 70);
            this.btnShowSW.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowSW.Name = "btnShowSW";
            this.btnShowSW.Size = new System.Drawing.Size(80, 30);
            this.btnShowSW.TabIndex = 5;
            this.btnShowSW.Text = "SW";
            this.btnShowSW.UseVisualStyleBackColor = true;
            this.btnShowSW.Click += new System.EventHandler(this.btnShowSW_Click);
            // 
            // btnShowRHO
            // 
            this.btnShowRHO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowRHO.Location = new System.Drawing.Point(403, 104);
            this.btnShowRHO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowRHO.Name = "btnShowRHO";
            this.btnShowRHO.Size = new System.Drawing.Size(80, 30);
            this.btnShowRHO.TabIndex = 6;
            this.btnShowRHO.Text = "RHO";
            this.btnShowRHO.UseVisualStyleBackColor = true;
            this.btnShowRHO.Click += new System.EventHandler(this.btnShowRHO_Click);
            // 
            // btnShowKDP
            // 
            this.btnShowKDP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowKDP.Location = new System.Drawing.Point(403, 138);
            this.btnShowKDP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowKDP.Name = "btnShowKDP";
            this.btnShowKDP.Size = new System.Drawing.Size(80, 30);
            this.btnShowKDP.TabIndex = 7;
            this.btnShowKDP.Text = "KDP";
            this.btnShowKDP.UseVisualStyleBackColor = true;
            this.btnShowKDP.Click += new System.EventHandler(this.btnShowKDP_Click);
            // 
            // btnShowVEL
            // 
            this.btnShowVEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowVEL.Location = new System.Drawing.Point(403, 172);
            this.btnShowVEL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowVEL.Name = "btnShowVEL";
            this.btnShowVEL.Size = new System.Drawing.Size(80, 30);
            this.btnShowVEL.TabIndex = 8;
            this.btnShowVEL.Text = "VEL";
            this.btnShowVEL.UseVisualStyleBackColor = true;
            this.btnShowVEL.Click += new System.EventHandler(this.btnShowVEL_Click);
            // 
            // btnShowZDR
            // 
            this.btnShowZDR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowZDR.Location = new System.Drawing.Point(403, 206);
            this.btnShowZDR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowZDR.Name = "btnShowZDR";
            this.btnShowZDR.Size = new System.Drawing.Size(80, 30);
            this.btnShowZDR.TabIndex = 9;
            this.btnShowZDR.Text = "ZDR";
            this.btnShowZDR.UseVisualStyleBackColor = true;
            this.btnShowZDR.Click += new System.EventHandler(this.btnShowZDR_Click);
            // 
            // btnShowPHI
            // 
            this.btnShowPHI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowPHI.Location = new System.Drawing.Point(403, 240);
            this.btnShowPHI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnShowPHI.Name = "btnShowPHI";
            this.btnShowPHI.Size = new System.Drawing.Size(80, 30);
            this.btnShowPHI.TabIndex = 10;
            this.btnShowPHI.Text = "PHI";
            this.btnShowPHI.UseVisualStyleBackColor = true;
            this.btnShowPHI.Click += new System.EventHandler(this.btnShowPHI_Click);
            // 
            // flpWp
            // 
            this.flpWp.BackColor = System.Drawing.Color.LightGray;
            this.flpWp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpWp.Location = new System.Drawing.Point(0, 348);
            this.flpWp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpWp.Name = "flpWp";
            this.flpWp.Size = new System.Drawing.Size(490, 64);
            this.flpWp.TabIndex = 11;
            // 
            // frmReadDPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(490, 412);
            this.Controls.Add(this.flpWp);
            this.Controls.Add(this.btnShowPHI);
            this.Controls.Add(this.btnShowZDR);
            this.Controls.Add(this.btnShowVEL);
            this.Controls.Add(this.btnShowKDP);
            this.Controls.Add(this.btnShowRHO);
            this.Controls.Add(this.btnShowSW);
            this.Controls.Add(this.btnShowDBZ);
            this.Controls.Add(this.pbShow);
            this.Controls.Add(this.btnLayerDown);
            this.Controls.Add(this.btnLayerUp);
            this.Controls.Add(this.btnOpen);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(450, 404);
            this.Name = "frmReadDPR";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "显示";
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnLayerUp;
        private System.Windows.Forms.Button btnLayerDown;
        private System.Windows.Forms.PictureBox pbShow;
        private System.Windows.Forms.Button btnShowDBZ;
        private System.Windows.Forms.Button btnShowSW;
        private System.Windows.Forms.Button btnShowRHO;
        private System.Windows.Forms.Button btnShowKDP;
        private System.Windows.Forms.Button btnShowVEL;
        private System.Windows.Forms.Button btnShowZDR;
        private System.Windows.Forms.Button btnShowPHI;
        private System.Windows.Forms.FlowLayoutPanel flpWp;
    }
}

