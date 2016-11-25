using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadDPR_Winform
{
    public partial class frmProgress : Form
    {
        /// <summary>
        /// 标记窗体是否可以关闭
        /// </summary>
        private bool m_bExit = false;

        public int nProgress = 0;
        public string strProgress = "";
        public frmProgress()
        {
            InitializeComponent();
        }

        private void frmProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = m_bExit;
            m_bExit = false;
        }

        private void frmProgress_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt) && (e.KeyCode == Keys.F4))
            {
                m_bExit = true;
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            this.lblText.Text = strProgress + nProgress.ToString() + "%";

            this.pb.Value = nProgress;
            if (nProgress == 100)
            {
                timerRefresh.Stop();
                timerRefresh.Dispose();
                this.Close();
            }
        }

        public void SetText(string strText)
        {
            strProgress = strText;
            this.lblText.Text = strProgress + nProgress.ToString() + "%";
        }
    }
}
