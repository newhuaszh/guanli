using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadDPR_Winform
{
    public partial class frmReadDPR : Form
    {
        DprRdaData mRadarData = null;
        DrawData draw = new DrawData();
        RadarReader mRadrReader = new RadarReader();
        Bitmap bmpMain = null;
        Bitmap bmpDBZ = null;
        Bitmap bmpSW = null;
        Bitmap bmpRHO = null;
        Bitmap bmpKDP = null;
        Bitmap bmpVEL = null;
        Bitmap bmpZDR = null;
        Bitmap bmpPHI = null;
        int nLayer = 0;

        public frmReadDPR()
        {
            InitializeComponent();
        }

        private void InitBmp()
        {
            if (bmpDBZ != null)
            {
                bmpDBZ.Dispose();
                bmpDBZ = null;
            }
            if (bmpSW != null)
            {
                bmpSW.Dispose();
                bmpSW = null;
            }
            if (bmpRHO != null)
            {
                bmpRHO.Dispose();
                bmpRHO = null;
            }
            if (bmpKDP != null)
            {
                bmpKDP.Dispose();
                bmpKDP = null;
            }
            if (bmpVEL != null)
            {
                bmpVEL.Dispose();
                bmpVEL = null;
            }
            if (bmpZDR != null)
            {
                bmpZDR.Dispose();
                bmpZDR = null;
            }
            if (bmpPHI != null)
            {
                bmpPHI.Dispose();
                bmpPHI = null;
            }
        }

        #region 上方按钮
        /// <summary>
        /// 打开数据文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "DataFile(*.bin,*.bz2)|*.bin;*.bz2|All Files(*.*)|*.*";
            openDlg.InitialDirectory = Application.StartupPath;
            openDlg.RestoreDirectory = true;
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                frmProgress frmpg = new frmProgress();
                frmpg.SetText("数据解码中：");
                frmpg.StartPosition = FormStartPosition.CenterParent;
                new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        while (true)
                        {
                            Thread.Sleep(50);
                            if (frmpg.Visible)
                            {
                                break;
                            }
                        }
                        //frmpg.strProgress = "数据解码中：";
                        mRadarData = mRadrReader.ReadData(@openDlg.FileName, frmpg);
                        frmpg.nProgress = 85;
                        frmpg.strProgress = "解码完成，绘制中：";
                        if (bmpMain != null)
                        {
                            bmpMain.Dispose();
                        }
                        InitBmp();
                        bmpMain = draw.Draw(mRadarData, nLayer, 0);
                        pbShow.Image = bmpMain;
                        frmpg.nProgress = 95;
                        Action<FlowLayoutPanel, int> actBar = draw.DrawColBar;
                        frmpg.Invoke(actBar, new object[] { flpWp, 0 });
                    }
                    catch (Exception ex)
                    {
                        
                    }
                    finally
                    {
                        frmpg.nProgress = 100;
                    }
                })).Start();
                frmpg.ShowDialog();
            }
        }
        private void btnLayerUp_Click(object sender, EventArgs e)
        {
            if (mRadarData == null)
            {
                return;
            }
            if (nLayer < 8)
            {
                nLayer++;
            }
            else
            {
                return;
            }
            if (bmpMain != null)
            {
                bmpMain.Dispose();
            }
            bmpMain = draw.Draw(mRadarData, nLayer, 0);
            pbShow.Image = bmpMain;
        }

        private void btnLayerDown_Click(object sender, EventArgs e)
        {
            if (mRadarData == null)
            {
                return;
            }
            if (nLayer > 0)
            {
                nLayer--;
            }
            else
            {
                return;
            }
            if (bmpMain != null)
            {
                bmpMain.Dispose();
            }
            bmpMain = draw.Draw(mRadarData, nLayer, 0);
            pbShow.Image = bmpMain;
        }
        #endregion 上方按钮

        #region 右侧按钮
        private void SetSingleBmp(int nType, ref Bitmap bmpSingle, string strTitle)
        {
            if (mRadarData == null)
            {
                return;
            }
            frmSingleBmp fsb = new frmSingleBmp();
            fsb.Text = strTitle;
            if (bmpSingle == null)
            {
                bmpSingle = draw.Draw(mRadarData, nLayer, nType);
            }
            
            fsb.pbShow.Image = bmpSingle;
            draw.DrawColBar(fsb.flpWp, nType);
            fsb.Show();
        }

        private void btnShowDBZ_Click(object sender, EventArgs e)
        {
            SetSingleBmp(0, ref bmpDBZ, "DBZ");
        }

        private void btnShowSW_Click(object sender, EventArgs e)
        {
            SetSingleBmp(2, ref bmpSW, "SW");
        }

        private void btnShowRHO_Click(object sender, EventArgs e)
        {
            SetSingleBmp(4, ref bmpRHO, "RHO");
        }

        private void btnShowKDP_Click(object sender, EventArgs e)
        {
            SetSingleBmp(6, ref bmpKDP, "KDP");
        }

        private void btnShowVEL_Click(object sender, EventArgs e)
        {
            SetSingleBmp(1, ref bmpVEL, "VEL");
        }

        private void btnShowZDR_Click(object sender, EventArgs e)
        {
            SetSingleBmp(3, ref bmpZDR, "ZDR");
        }

        private void btnShowPHI_Click(object sender, EventArgs e)
        {
            SetSingleBmp(5, ref bmpPHI, "PHI");
        }
        #endregion 右侧按钮
    }
}
