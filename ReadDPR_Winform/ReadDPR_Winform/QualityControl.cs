using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadDPR_Winform
{
    class QualityControl
    {
        public QualityControl(float[,,] phiRaw, float[,,] dbzRaw, float[,,] rhoRaw)
        {
            this.phiRaw = phiRaw;
            this.dbzRaw = dbzRaw;
            this.rhoRaw = rhoRaw;
        }
        float[,,] phiRaw;
        float[,,] dbzRaw;
        float[,,] rhoRaw;
        public float[,,] firPhiDp;
        public const int firOrder = 60;
        private readonly double[] firCoeff_30 = { 0.01040850049,0.0136551033,0.01701931136,0.0204494327,
                                                0.0238905658,0.02728575662,0.03057723021,0.03370766631,
                                                0.03662148602,0.03926611662,0.04159320123,0.04355972181,
                                                0.04512900539,0.04627158699,0.04696590613,0.04719881804,
                                                0.04696590613,0.04627158699,0.04512900539,0.04355972181,
                                                0.04159320123,0.03926611662,0.03662148602,0.03370766631,
                                                0.03057723021,0.02728575662,0.0238905658,0.0204494327,
                                                0.01701931136,0.0136551033,0.01040850049};

        private readonly double[] firCoeff_60 = {
                                                0.005192387815,0.006000584633,0.006826878703,
                                                0.007668199579,0.008521340618,0.009382975237,
                                                0.01024967409,0.01111792308,0.0119841421,
                                                0.01284470437,0.01369595621,0.01453423726,
                                                0.01535590085,0.01615733448,0.01693498027,
                                                0.01768535525,0.01840507134,0.01909085485,
                                                0.01973956552,0.02034821473,0.02091398302,
                                                0.02143423665,0.02190654305,0.02232868523,
                                                0.0226986749,0.02301476423,0.02327545631,
                                                0.02347951399,0.02362596732,0.02371411929,
                                                0.02374355002,0.02371411929,0.02362596732,
                                                0.02347951399,0.02327545631,0.02301476423,
                                                0.0226986749,0.02232868523,0.02190654305,
                                                0.02143423665,0.02091398302,0.02034821473,
                                                0.01973956552,0.01909085485,0.01840507134,
                                                0.01768535525,0.01693498027,0.01615733448,
                                                0.01535590085,0.01453423726,0.01369595621,
                                                0.01284470437,0.0119841421,0.01111792308,
                                                0.01024967409,0.009382975237,0.008521340618,
                                                0.007668199579,0.006826878703,0.006000584633, 0.005192387815 };
        private float[,,] DataInitial(int i, int j, int k, float value)
        {
            float[,,] outData = new float[i, j, k];
            for (int layer = 0; layer < i; layer++)
            {
                for (int rad = 0; rad < j; rad++)
                {
                    for (int bin = 0; bin < k; bin++)
                    {
                        outData[layer, rad, bin] = value;
                    }
                }
            }
            return outData;
        }
        /// <summary>
        /// 求取均方根误差
        /// </summary>
        /// <param name="phiDp"></param>
        /// <returns></returns>
        private float STD(List<float> phiDp)
        {
            float sum = 0;
            int dataCnt = 0;
            float deviation = 0;
            float mean;

            for (int i = 0; i < phiDp.Count; i++)
            {
                if (phiDp[i] != -999)
                {
                    sum = sum + phiDp[i];
                    dataCnt++;
                }

            }
            mean = sum / dataCnt;

            double variance = 0;
            for (int i = 0; i < phiDp.Count; i++)
            {
                variance += Math.Pow((phiDp[i] - mean), 2);

            }

            if (dataCnt == 0)
            {
                deviation = 999;

            }
            else
            {
                deviation = Convert.ToSingle(Math.Sqrt(variance / dataCnt));

            }
            return deviation;
        }


        /// <summary>
        /// 最小二乘法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public float LeastSquareMethod(float[] x, float[] y)
        {
            List<float> _xList = new List<float>();
            List<float> _yList = new List<float>();
            float a = 0;
            float b = 0;
            int ii = 0;
            float sum_x = 0;
            float sum_y = 0;
            float sum_xy = 0;
            float sum_x2 = 0;

            //int dataCnt = Math.Min(Information.UBound(x), Information.UBound(y)) + 1;
            int dataCnt = 0;
            // int _zdataCnt = 0;
            for (int i = 0; i < y.Length; i++)
            {
                if (y[i] != -999)
                {
                    _xList.Add(x[i]);
                    _yList.Add(y[i]);
                    dataCnt++;
                }
            }
            if (dataCnt < y.Length / 2)
            {
                //a = 0;
                a = -999;
                b = y[0];
                return a;
            }
            else
            {
                ////去除最大值、最小值
                //_yList.RemoveAt(_yList.IndexOf(_yList.Max()));
                //_yList.RemoveAt(_yList.IndexOf(_yList.Min()));
                for (ii = 0; ii < _yList.Count; ii++)
                {
                    //X和
                    //sum_x += Convert.ToSingle(_xList[ii]);
                    sum_x += _xList[ii];
                    //Y和
                    sum_y += _yList[ii];
                    //X*Y和
                    sum_xy += _xList[ii] * _yList[ii];
                    //X2和
                    sum_x2 += _xList[ii] * _xList[ii];
                }

                //nΣx2-(Σx)2
                float divisor = _yList.Count * sum_x2 - sum_x * sum_x;
                // if (Math.Abs(divisor) > 1E-06)
                {

                    // a=(nΣxy - ΣxΣy)/[nΣx2-(Σx)2]
                    a = (_yList.Count * sum_xy - sum_x * sum_y) / divisor;

                    // b=(Σx2Σy - ΣxyΣx)/[nΣx2-(Σx)2]
                    b = (sum_x2 * sum_y - sum_xy * sum_x) / divisor;

                }
                return a;
            }
        }
        /// <summary>
        /// 单根径向FIR滤波
        /// </summary>
        /// <param name="phiDpRadial"></param>
        /// <returns></returns>
        public float FirFilter(List<float> phiDpRadial)
        {
            double sum = 0;
            int dataCnt = 0;
            for (int ii = 0; ii < firCoeff_60.Length; ii++)
            {
                if (phiDpRadial[ii] != -999)
                {
                    dataCnt++;

                }
                else
                {
                    phiDpRadial[ii] = 0;
                }
            }
            if (dataCnt == firCoeff_60.Length)
            {
                for (int i = 0; i < firCoeff_60.Length; i++)
                {
                    sum = sum + phiDpRadial[i] * firCoeff_60[i];
                }

                return Convert.ToSingle(sum);
            }

            else if (dataCnt > firCoeff_60.Length / 2 && dataCnt < firCoeff_60.Length)
            {
                for (int i = 0; i < firCoeff_60.Length; i++)
                {
                    if (phiDpRadial[i] != -999)
                    {
                        sum = sum + phiDpRadial[i];

                    }

                }
                return Convert.ToSingle(sum / dataCnt);
            }
            else
            {
                return -999;
            }

        }
        /// <summary>
        /// 判断10个连续距离库内满足rho[0.9~1]的个数，并计算phi的std
        /// </summary>
        /// <param name="k"></param>
        /// <param name="rhoCnt"></param>
        /// <param name="phiStd"></param>
        private void Select(int i, int j, int k, out int rhoCnt, out double phiStd)
        {
            float sum = 0;
            float mean;
            List<float> philist = new List<float>();

            rhoCnt = 0;
            for (int mIndex = k; mIndex < k + 10; mIndex++)
            {
                if (rhoRaw[i, j, mIndex] > 0.9 && rhoRaw[i, j, k] < 1)
                {
                    rhoCnt++;
                }
                if (phiRaw[i, j, mIndex] != -999)
                {
                    philist.Add(phiRaw[i, j, mIndex]);
                }
            }
            if (philist.Count != 0)
            {
                mean = philist.Sum() / philist.Count();
                foreach (float num in philist)
                {
                    sum = sum + (num - mean) * (num - mean);
                }
                phiStd = Math.Sqrt(sum / philist.Count());
            }
            else
            { phiStd = 999; }

        }
        /// <summary>
        /// 计算原始数据中数据质量较好的PhiDp点
        /// </summary>
        /// <param name="phiData"></param>
        /// <param name="rhoData"></param>
        /// <param name="phiDpIni"></param> 合理初相位的点
        /// <param name="phiIndex"></param> 
        private float[,,] GainPhiDpIni()
        {
            float[,,] phiDpIni = DataInitial(9, 720, 1200, -999);
            for (int i = 0; i < phiRaw.GetLength(0); i++)
            {
                for (int j = 0; j < phiRaw.GetLength(1); j++)
                {
                    for (int k = 0; k < phiRaw.GetLength(2) - 10; k++)
                    {
                        int rhoCnt;
                        double phiStd;
                        Select(i, j, k, out rhoCnt, out phiStd);
                        if (rhoCnt == 10 && phiStd < 15)   //有效的PhiDp值和对应的索引位置
                        {
                            phiDpIni[i, j, k] = phiRaw[i, j, k];
                        }
                        else
                        {
                            phiDpIni[i, j, k] = -999;
                        }
                    }
                }

            }
            return phiDpIni;
        }
        /// <summary>
        /// 寻找距离无效值点最近的PhiDp值有效值代替无效值
        /// </summary>
        /// <param name="phiData"></param>
        /// <param name="rhoData"></param>
        /// <param name="phiCorrect"></param>
        public float[,,] PhiDpCorrect()
        {
            float[,,] phiCorrect = DataInitial(9, 720, 1200, -999);
            float[,,] phiDpIni = GainPhiDpIni();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 720; j++)
                {
                    //*****************对单根径向的数据进行操作***********************//
                    List<float> phiRadial = new List<float>();
                    List<int> phiRadIndex = new List<int>();
                    for (int k = 0; k < phiRaw.GetLength(2); k++)
                    {
                        // 找到单根径向上有效的初相位（相对）的点添加到list中
                        if (phiDpIni[i, j, k] != -999)
                        {
                            phiRadial.Add(phiDpIni[i, j, k]);     //初相位的值
                            phiRadIndex.Add(k);   //初相位对应的索引位置
                        }
                    }
                    if (phiRadIndex.Count < 10)  //获取正确的初相位值以及对应的索引      
                    {
                        continue;
                    }
                    else
                    {
                        //int maxIndex = phiRadIndex.Max();
                        for (int k = 0; k < 1200; k++)
                        {
                            if (phiRadial.Count != 0 && k < phiRadIndex[0])  //距离雷达较近距离处的PhiDp订正统一用初相位代替
                            {
                                phiCorrect[i, j, k] = phiRadIndex[0];   //Initial PhiDp;
                            }
                            else if (phiRadial.Count != 0 && phiDpIni[i, j, k] == -999 && phiRaw[i, j, k] != -999)
                            {
                                List<double> indexDiff = new List<double>();//
                                for (int nIndex = 0; nIndex < phiRadIndex.Count; nIndex++)
                                {
                                    indexDiff.Add(Math.Abs(phiRadIndex[nIndex] - k));//PhiList的index与k的差值
                                }
                                //int minDiff = indexDiff.Min();
                                int minDiffIndex = indexDiff.IndexOf(indexDiff.Min());  //最小差值对应的索引位置
                                phiCorrect[i, j, k] = phiRadial[minDiffIndex];

                            }
                            else
                            {
                                phiCorrect[i, j, k] = phiRaw[i, j, k];
                            }
                            phiRadial.Clear();
                            phiRadIndex.Clear();
                        }
                    }
                }
            }
            return phiCorrect;
        }
        /// <summary>
        /// Fir对PhiDpCorrect进行滤波
        /// </summary>
        public float[,,] PhiDpFir(frmProgress frmpg)
        {
            float[,,] phiCorrect = PhiDpCorrect();
            frmpg.nProgress = 60;
            float[,,] firPhiDp = DataInitial(9, 720, 1200, -999);
            for (int i = 0; i < phiRaw.GetLength(0); i++)
            {
                for (int j = 0; j < phiRaw.GetLength(1); j++)
                {
                    List<float> phiDpIni_radial = new List<float>();

                    for (int kk = 0; kk < phiRaw.GetLength(2); kk++)
                    {

                        if (phiCorrect[i, j, kk] != -999)
                        {
                            phiDpIni_radial.Add(phiCorrect[i, j, kk]);
                        }

                    }
                    for (int k = 0; k < phiRaw.GetLength(2) - firOrder / 2; k++) //60阶
                    {
                        if (phiDpIni_radial.Count == 0)
                        {
                            firPhiDp[i, j, k] = -999;
                        }
                        else
                        {
                            if (k < firOrder / 2)
                            {
                                firPhiDp[i, j, k] = phiDpIni_radial[0];
                            }
                            else
                            {
                                List<float> firInPut = new List<float>();
                                for (int mIndex = k - firOrder / 2; mIndex < k + firOrder / 2 + 1; mIndex++)
                                {
                                    firInPut.Add(phiCorrect[i, j, mIndex]);
                                }
                                firPhiDp[i, j, k] = FirFilter(firInPut);
                                firInPut.Clear();
                            }
                        }

                    }
                    phiDpIni_radial.Clear();
                }
                frmpg.nProgress = (int)(60 + (i + 1d) / phiRaw.GetLength(0) * 15);
            }
            
            return firPhiDp;
        }

        public float[,,] GetKdpData(frmProgress frmpg)
        {
            //firPhiDp = DataInitial(9, 720, 1200, -999);
            firPhiDp = PhiDpFir(frmpg);
            float[,,] kdpData = DataInitial(9, 720, 1200, -999);
            int nCount = 0;
            int nCountX = phiRaw.GetLength(0);
            int nCountY = phiRaw.GetLength(1);
            int nCountZ = phiRaw.GetLength(2);
            for (int i = 0; i < nCountX; i++)
            {
                for (int j = 0; j < nCountY; j++)
                {
                    for (int k = 15; k < nCountZ - 15; k++)
                    {
                        if (dbzRaw[i, j, k] != -999)
                        {
                            if (dbzRaw[i, j, k] < 35 && dbzRaw[i, j, k] != -999)
                            {
                                nCount = 30;
                                float[] y = new float[nCount];
                                float[] x = new float[nCount];
                                float[] z = new float[nCount];
                                int linerCount = 0;
                                for (int linerIndex = k - nCount / 2; linerIndex < k + nCount / 2; linerIndex++)
                                {

                                    y[linerCount] = firPhiDp[i, j, linerIndex];
                                    x[linerCount] = (float)(linerIndex * 0.25 + 0.25);
                                    z[linerCount] = rhoRaw[i, j, linerIndex];
                                    linerCount++;
                                }

                                kdpData[i, j, k] = LeastSquareMethod(x, y);

                            }
                            else if (dbzRaw[i, j, k] >= 35 && dbzRaw[i, j, k] <= 45)
                            {
                                nCount = 20;
                                float[] y = new float[nCount];
                                float[] x = new float[nCount];
                                float[] z = new float[nCount];
                                int linerCount = 0;
                                for (int linerIndex = k - nCount / 2; linerIndex < k + nCount / 2; linerIndex++)
                                {
                                    y[linerCount] = firPhiDp[i, j, linerIndex];
                                    x[linerCount] = (float)(linerIndex * 0.25 + 0.25);
                                    z[linerCount] = rhoRaw[i, j, linerIndex];
                                    linerCount++;
                                }

                                kdpData[i, j, k] = LeastSquareMethod(x, y);
                            }
                            else
                            {
                                nCount = 10;
                                float[] y = new float[nCount];
                                float[] x = new float[nCount];
                                float[] z = new float[nCount];
                                int linerCount = 0;
                                for (int linerIndex = k - nCount / 2; linerIndex < k + nCount / 2; linerIndex++)
                                {
                                    y[linerCount] = firPhiDp[i, j, linerIndex];
                                    x[linerCount] = (float)(linerIndex * 0.25 + 0.25);
                                    z[linerCount] = rhoRaw[i, j, linerIndex];
                                    linerCount++;
                                }

                                kdpData[i, j, k] = LeastSquareMethod(x, y);
                            }

                        }
                        else
                        {
                            kdpData[i, j, k] = -999;
                        }
                    }
                }
                frmpg.nProgress = 75 + (int)((i + 1d) / nCountX * 10);
            }

            phiRaw = null;
            dbzRaw = null;
            rhoRaw = null;
            return kdpData;
        }
    }
}
