using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReadDPR_Winform
{

    class DrawData
    {
        List<Color[]> clrList = new List<Color[]>();
        List<double[]> thresholdList = new List<double[]>();
        public DrawData()
        {
            clrList.Add(refClrNum);
            clrList.Add(velClrNum);
            clrList.Add(swClrNum);
            clrList.Add(zdrClrNum);
            clrList.Add(rhoClrNum);
            clrList.Add(phiClrNum);
            clrList.Add(kdpClrNum);

            thresholdList.Add(refThreshold);
            thresholdList.Add(velThreshold);
            thresholdList.Add(swThreshold);
            thresholdList.Add(zdrThreshold);
            thresholdList.Add(rhoThreshold);
            thresholdList.Add(phiThreshold);
            thresholdList.Add(kdpThreshold);
        }
        Color[] refClrNum = new Color[]
       {
                Color.FromArgb(128,128,128),
                Color.FromArgb(0,230,255),
                Color.FromArgb(0,150,255),
                Color.FromArgb(0,0,255),
                Color.FromArgb(0,255,0),
                Color.FromArgb(0,200,0),
                Color.FromArgb(0,128,0),
                Color.FromArgb(255,255,0),
                Color.FromArgb(220,180,0),
                Color.FromArgb(255,180,0),
                Color.FromArgb(255,0,0),
                Color.FromArgb(170,0,0),
                Color.FromArgb(100,0,0),
                Color.FromArgb(255,0,255),
                Color.FromArgb(255,180,255),
       };
        double[] refThreshold = { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70 };

        Color[] velClrNum = new Color[]
        {

             Color.FromArgb(0x00,0x00,255),
            Color.FromArgb(0x7e,0xe0,0xfe),
            Color.FromArgb(0x00,0xe0,0xfe),
            Color.FromArgb(0x00,0xb0,0xb0),
            Color.FromArgb(0x00,0xfe,0x00),
            Color.FromArgb(0x00,0xc4,0x00),
            Color.FromArgb(0x00,0x80,0x00),
            Color.FromArgb(0xfe,0xfe,0xfe),
            Color.FromArgb(0xfc,0xfc,0xfc),
            Color.FromArgb(0xfe,0x00,0x00),
            Color.FromArgb(0xfe,0x58,0x58),
            Color.FromArgb(0xfe,0xb0,0xb0),
            Color.FromArgb(0xfe,0x7c,0x00),
            Color.FromArgb(0xfe,0xd2,0x00),
            Color.FromArgb(0xfe,0xfe,0x00),
            Color.FromArgb(0x7c,0x00,0x7c),
            Color.FromArgb(139,101,8),

        };
        double[] velThreshold = { -33, -27, -23, -20, -15, -10, -5, -1, 0, 1, 5, 10, 15, 20, 23, 27, 33 };

        Color[] swClrNum = new Color[]
        {
                Color.FromArgb(0,168,168),
                Color.FromArgb(176,176,255),
                Color.FromArgb(134,134,255),
                Color.FromArgb(36,36,255),
                Color.FromArgb(149,255,175),
                Color.FromArgb(26,255,83),
                Color.FromArgb(0,136,34),
                Color.FromArgb(255,255,128),
                Color.FromArgb(198,198,0),
                Color.FromArgb(138,138,0),
                Color.FromArgb(255,172,172),
                Color.FromArgb(255,132,132),
                Color.FromArgb(247,0,0),
                Color.FromArgb(255,164,255),
                Color.FromArgb(202,0,202),
                Color.FromArgb(0,0,0),
         };
        double[] swThreshold = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        Color[] zdrClrNum = new Color[]
        {
                Color.FromArgb(0,0,0),
                Color.FromArgb(51,51,51),
                Color.FromArgb(153,153,153),
                Color.FromArgb(204,204,204),
                Color.FromArgb(102,102,153),
                Color.FromArgb(0,0,153),
                Color.FromArgb(0,153,204),
                Color.FromArgb(51,255,204),
                Color.FromArgb(51,204,51),
                Color.FromArgb(255,255,51),
                Color.FromArgb(255,51,51),
                Color.FromArgb(204,0,0),
                Color.FromArgb(153,0,0),
                Color.FromArgb(204,102,153),
                Color.FromArgb(255,255,255),
                Color.FromArgb(102,0,102),

        };
        double[] zdrThreshold = { -4, -2, -1, -0.5, -0.25, 0, 0.25, 0.5, 1, 1.5, 2, 2.5, 3, 4, 5, 6 };

        Color[] phiClrNum = new Color[]
        {
                Color.FromArgb(0,0,0),
                Color.FromArgb(51,51,51),
                Color.FromArgb(153,153,153),
                Color.FromArgb(204,204,204),
                Color.FromArgb(102,102,153),
                Color.FromArgb(51,255,204),
                Color.FromArgb(51,204,51),
                Color.FromArgb(255,255,51),
                Color.FromArgb(255,51,51),
                Color.FromArgb(204,0,0),
                Color.FromArgb(153,0,0),
                Color.FromArgb(204,102,153),
                Color.FromArgb(255,255,255),
                Color.FromArgb(0,100,80),
                Color.FromArgb(155,107,55),
                Color.FromArgb(10,6,3),

        };
        double[] phiThreshold = { -20, 0, 20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280 };

        Color[] rhoClrNum = new Color[]
        {
             Color.FromArgb(47,47,255),
             Color.FromArgb(23,255,255),
             Color.FromArgb(0,196,196),
             Color.FromArgb(0,136,136),
             Color.FromArgb(0,128,64),
             Color.FromArgb(0,183,91),
             Color.FromArgb(0,255,113),
             Color.FromArgb(85,255,128),
             Color.FromArgb(255,255,0),
             Color.FromArgb(232,232,0),
             Color.FromArgb(255,183,111),
             Color.FromArgb(255,153,51),
             Color.FromArgb(242,121,0),
             Color.FromArgb(255,55,55),
             Color.FromArgb(198,0,0),
             Color.FromArgb(217,0,217),
        };
        double[] rhoThreshold = { 0, 0.1, 0.3, 0.5, 0.6, 0.7, 0.8, 0.85, 0.9, 0.92, 0.94, 0.95, 0.96, 0.97, 0.98, 0.99 };


        Color[] kdpClrNum = new Color[]
        {
          //Color.FromArgb(0,0,0),
                Color.FromArgb(205,205,205),
                Color.FromArgb(102,102,102),
                Color.FromArgb(51,51,51),
                Color.FromArgb(51,0,0),
                Color.FromArgb(102,0,0),
                Color.FromArgb(153,0,0),
                Color.FromArgb(204,51,51),
                Color.FromArgb(204,102,153),
                Color.FromArgb(153,102,153),
                Color.FromArgb(51,255,204),
                Color.FromArgb(0,153,51),
                Color.FromArgb(0,255,0),
                Color.FromArgb(255,255,0),
                Color.FromArgb(255,102,0),
                Color.FromArgb(255,204,102),
          //Color.FromArgb(102,0,102),
          //Color.FromArgb(55,55,55),
        };
        double[] kdpThreshold = { -3, -2, -1, -0.5, 0, 0.25, 0.5, 1, 1.5, 2, 2.5, 3, 4, 5, 7 };

        Color[] fuzzyClrNum = new Color[]
        {
            Color.FromArgb(0,204,102),
            Color.FromArgb(0,153,0),
            Color.FromArgb(255,0,0),
            Color.FromArgb(204,204,51),
            Color.FromArgb(153,153,153),
            Color.FromArgb(102,102,102),
            Color.FromArgb(0,255,255),
            Color.FromArgb(0,102,255),
            Color.FromArgb(255,153,153),
            Color.FromArgb(204,102,102),
            ////////2016-10-11
            Color.FromArgb(255,255,51),
            Color.FromArgb(255,51,51),
            Color.FromArgb(51,255,51),

        };

        float GetAngle(float x, float y)
        {
            float ret;
            float xoffset = x;
            float yoffset = y;
            if (xoffset == 0)
            {
                if (yoffset >= 0)
                    ret = 0;
                else
                    ret = 180;
            }
            else if (yoffset == 0)
            {
                if (xoffset > 0)
                    ret = 90;
                else
                    ret = 270;
            }
            else
            {
                float angletmp = (float)(System.Math.Atan(xoffset / yoffset) * 180 / 3.1415926);
                if (xoffset > 0 && yoffset < 0)
                    ret = angletmp + 180;
                else if (xoffset < 0 && yoffset > 0)
                    ret = angletmp + 360;
                else if (xoffset < 0 && yoffset < 0)
                    ret = 180 + angletmp;
                else
                    ret = angletmp;
            }
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The inpur array[,,]</param>
        /// <param name="threshold">the value threshold</param>
        /// <param name="colorbar">the colorBar color</param>
        /// <param name="nLayer">the scan layer</param>
        /// <param name="xCenter">the center of radar in bitmap</param>
        /// <param name="yCenter">the center of radar in bitmap</param>
        /// <returns></returns>
        private Bitmap DrawRadarData(float[,,] value, double[] threshold, Color[] colorbar, int nLayer, int xCenter, int yCenter)
        {
            Bitmap bmp = new Bitmap(xCenter * 2, yCenter * 2);
            for (int i = 0; i < xCenter * 2; i++)
            {
                for (int j = 0; j < yCenter * 2; j++)
                {
                    int nRadius = (int)(System.Math.Sqrt((i - xCenter) * (i - xCenter) + (j - yCenter) * (j - yCenter)));
                    if (nRadius >= xCenter)
                    {
                        continue;
                    }
                    int nRadialIndex;
                    if (nLayer > 1)
                    {
                        nRadialIndex = (int)Math.Floor(GetAngle(i - xCenter, yCenter - j));
                        if (nRadialIndex > 360)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        nRadialIndex = (int)Math.Floor(GetAngle(i - xCenter, yCenter - j) / 0.5);
                    }

                    if (value[nLayer, nRadialIndex, nRadius] != -999)
                    {
                        int nClrIndex = 0;

                        while (value[nLayer, nRadialIndex, nRadius] > threshold[nClrIndex] && nClrIndex < threshold.Length - 1)
                        {
                            nClrIndex++;
                        }
                        bmp.SetPixel(i, j, colorbar[nClrIndex]);

                    }
                }

            }

            return bmp;
        }
        public Bitmap Draw(DprRdaData radarData, int nLayer, int valType)
        {
            int xCenter = 1200;
            int yCenter = 1200;

            switch (valType)
            {
                case 0:
                    return DrawRadarData(radarData.refData, refThreshold, refClrNum, nLayer, xCenter, yCenter);
                case 1:
                    return DrawRadarData(radarData.velData, velThreshold, velClrNum, nLayer, xCenter, yCenter);
                case 2:
                    return DrawRadarData(radarData.swData, swThreshold, swClrNum, nLayer, xCenter, yCenter);
                case 3:
                    return DrawRadarData(radarData.zdrData, zdrThreshold, zdrClrNum, nLayer, xCenter, yCenter);
                case 4:
                    return DrawRadarData(radarData.rhoData, rhoThreshold, rhoClrNum, nLayer, xCenter, yCenter);
                case 5:
                    return DrawRadarData(radarData.phiData, phiThreshold, phiClrNum, nLayer, xCenter, yCenter);
                case 6:
                    return DrawRadarData(radarData.kdpData, kdpThreshold, kdpClrNum, nLayer, xCenter, yCenter);
                default:
                    return DrawRadarData(radarData.refData, refThreshold, refClrNum, nLayer, xCenter, yCenter);
            }
        }   

        public void DrawColBar(FlowLayoutPanel flp, int valType)
        {
            flp.Controls.Clear();
            var threshold = thresholdList[valType];
            var clrNum = clrList[valType];
            for (int i = 0; i < threshold.Length; i++)
            {
                Label lb = new Label();
                lb.Width = 60;
                lb.Height = 20;
                lb.Text = threshold[i].ToString();
                lb.BackColor = clrNum[i];
                lb.TextAlign = ContentAlignment.MiddleCenter;
                flp.Controls.Add(lb);
            }
        }

    }
}
