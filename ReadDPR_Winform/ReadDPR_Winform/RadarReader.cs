using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
using System.Collections;
using System.Diagnostics.Contracts;

namespace ReadDPR_Winform
{
    public class DprRdaData
    {
        public float[,,] refData { get; private set; }
        public float[,,] velData { get; private set; }
        public float[,,] swData { get; private set; }
        public float[,,] rhoData { get; private set; }
        public float[,,] phiData { get; private set; }
        public float[,,] zdrData { get; private set; }
        public float[,,] kdpData { get; private set; }
        public float[] elevData { get; private set; }
        public DprRdaData(float[,,] Ref, float[,,] Vel, float[,,] Sw, float[,,] Rho, float[,,] Phi, float[,,] Zdr, float[,,] Kdp, float[] ElevData)
        {
            refData = Ref;
            velData = Vel;
            swData = Sw;
            rhoData = Rho;
            phiData = Phi;
            zdrData = Zdr;
            kdpData = Kdp;
            elevData = ElevData;

        }
    }
    class RadarReader
    {
        class BigEndianConvert
        {
            public static uint ToUInt16(byte[] data)
            {
                Contract.Assume(data.Length <= 2);
                return BitConverter.ToUInt16(new byte[4 - data.Length].Concat(data).Reverse().ToArray(), 0);
            }
            public static int ToInt16(byte[] data)
            {
                Contract.Assume(data.Length <= 2);
                return BitConverter.ToInt16(new byte[4 - data.Length].Concat(data).Reverse().ToArray(), 0);
            }
            public static uint ToUInt32(byte[] data)
            {
                Contract.Assume(data.Length <= 4);
                return BitConverter.ToUInt32(new byte[4 - data.Length].Concat(data).Reverse().ToArray(), 0);
            }
            public static float ToSingle(byte[] data)
            {
                Contract.Assume(data.Length <= 4);
                return BitConverter.ToSingle(new byte[4 - data.Length].Concat(data).Reverse().ToArray(), 0);
            }
            public static byte[] ToBytes(uint num, int size)
            {
                Contract.Assume(size <= 4);
                return BitConverter.GetBytes(num).Take(size).Reverse().ToArray();
            }
            public static byte[] ToBytesInt(int num, int size)
            {
                Contract.Assume(size <= 4);
                return BitConverter.GetBytes(num).Take(size).Reverse().ToArray();
            }
            public static byte[] ToBytesSingle(float num, int size)
            {
                Contract.Assume(size <= 4);
                return BitConverter.GetBytes(num).Take(size).Reverse().ToArray();
            }
        }
        public struct BigEndianUInt16
        {
            const int size = 2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = size)]
            byte[] data;
            public static implicit operator uint (BigEndianUInt16 d)
            { return BigEndianConvert.ToUInt16(d.data); }
            public static implicit operator BigEndianUInt16(uint d)
            { return new BigEndianUInt16() { data = BigEndianConvert.ToBytes(d, size) }; }
            public override string ToString()
            { return ((uint)this).ToString(); }
        }
        public struct BigEndianInt16
        {
            const int size = 2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = size)]
            byte[] data;
            public static implicit operator int (BigEndianInt16 d)
            { return BigEndianConvert.ToInt16(d.data); }
            public static implicit operator BigEndianInt16(int d)
            { return new BigEndianInt16() { data = BigEndianConvert.ToBytesInt(d, size) }; }
            public override string ToString()
            { return ((int)this).ToString(); }
        }
        public struct BigEndianUInt32
        {
            const int size = 4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = size)]
            byte[] data;
            public static implicit operator uint (BigEndianUInt32 d)
            { return BigEndianConvert.ToUInt32(d.data); }
            public static implicit operator BigEndianUInt32(uint d)
            { return new BigEndianUInt32() { data = BigEndianConvert.ToBytes(d, size) }; }
            public override string ToString()
            { return ((uint)this).ToString(); }
        }
        public struct BigEndianSingle
        {
            const int size = 4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = size)]
            byte[] data;
            public static implicit operator float (BigEndianSingle d)
            { return BigEndianConvert.ToSingle(d.data); }
            public static implicit operator BigEndianSingle(float d)
            { return new BigEndianSingle() { data = BigEndianConvert.ToBytesSingle(d, size) }; }
            public override string ToString()
            { return ((float)this).ToString(); }
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MessageHeader
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public byte[] spare;
            //public ushort messageSize; //Message size in halfwords
            public BigEndianUInt16 messageSize; //Message size in halfwords
            public byte rdaRedCh;      // RDA Redundant Channel
            public byte messageType;   // Message Type
            //public ushort idSeqNumber;   //ID Sequence Number
            //public ushort julianDate;  //Julian date
            public BigEndianUInt16 idSeqNumber;   //ID Sequence Number
            public BigEndianUInt16 julianDate;  //Julian date
            //public uint msOfDay;  //Number of milliseconds from midnight
            //public ushort numOfmesSeg; // Segment number of this message
            //public ushort messageSegmentNumber;
            public BigEndianUInt32 msOfDay;  //Number of milliseconds from midnight
            public BigEndianUInt16 numOfmesSeg; // Segment number of this message
            public BigEndianUInt16 messageSegmentNumber;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GenericFormatBlock
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] radarId;  //ICAO Radar Identifier
            public BigEndianUInt32 colTime;   //Collection Time
            public BigEndianUInt16 modJulData; //Modified Julian Date;
            public BigEndianUInt16 azimuthNum; // Raial number within elevation scan
            public BigEndianSingle azAngle; // Azimuth angle at which radial data was collected
            public char CompIndicator;  //Message Type 31 is compressed
            public byte spare;
            public BigEndianUInt16 radLength;
            public byte azReSp;
            public byte radStatus;
            public byte elevNum;
            public byte cutSecNum;
            public BigEndianSingle elevAngle;
            public byte radSpotBlank;
            public sbyte azIndexMode;
            public BigEndianUInt16 dataBlockCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
            public uint[] dataBlockPointer;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct VolumeDataConstantType
        {
            public char dataBlockType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public char[] dataName;
            public BigEndianUInt16 LPTUP;
            public sbyte versionNumber1;
            public sbyte versionNumber2;
            public BigEndianSingle lat;
            public BigEndianSingle lon;
            public BigEndianInt16 siteHeight;
            public BigEndianUInt16 feedhornHeight;
            public BigEndianSingle calibrationConstant;
            public BigEndianSingle horSHV;
            public BigEndianSingle velSHV;
            public BigEndianSingle diffReflect;
            public BigEndianSingle initalDiffReflect;
            public BigEndianUInt16 volCovPatNum;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] spares;

        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ElevationDataConstantType
        {
            public char dataBlockType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public char[] dataName;
            public BigEndianUInt16 LPTUP;
            public BigEndianUInt16 ATMOS;
            public BigEndianSingle calibrationConstant;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RadialDataConstantType
        {
            public char dataBlockType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public char[] dataName;
            public BigEndianUInt16 LPTUP;
            public BigEndianInt16 unambiguRange;
            public BigEndianSingle noiseLevelHor;
            public BigEndianSingle noiseLevelVel;
            public BigEndianInt16 nyquistVelocity;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] spares;

        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DescripOfDataMomentType
        {
            public char dataBlockType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public char[] dataMomentName;
            public BigEndianUInt32 reserved;
            public BigEndianUInt16 numberOfDataMomentGates;
            public BigEndianInt16 dataMomentRange;
            public BigEndianInt16 dataMomentRangeSampleInterval;
            public BigEndianInt16 TOVER;
            public BigEndianInt16 SNRThreshold;
            public byte controlFlag;
            public sbyte dataWordSize;
            public BigEndianSingle scaLe;
            public BigEndianSingle offset;

        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct MomentType1
        {
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            //public byte[] resvered;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1832)]
            public byte[] mDBZ;
        }
        public struct MomentType2
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1192)]
            public byte[] mVEL;
        }
        public struct MomentType3
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1192)]
            public byte[] mSW;
        }
        public struct MomentType4
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1192)]
            public byte[] mRHO;
        }
        public struct MomentType5
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1192)]
            public BigEndianUInt16[] mPHI;
        }
        public struct MomentType6
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1192)]
            public byte[] mZDR;
        }
        static float Big2LittleSingle(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            float result = BitConverter.ToSingle(bytes, 0);

            return result;
        }
        static UInt16 Big2LittleUInt16(UInt16 value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            UInt16 result = BitConverter.ToUInt16(bytes, 0);

            return result;
        }
        static float DecodeByte(byte code, float scale, float offset)
        {

            if (code >= 2 && code <= 255)
            {
                float value = (code - offset) / scale;
                return value;
            }
            else
            {
                float value = -999;
                return value;
            }

        }

        static float DecodeUShort(ushort code, float scale, float offset)
        {
            if (code >= 2 && code <= 1023)
            {
                float value = (code - offset) / scale;
                return value;
            }
            else
            {
                float value = -999;
                return value;
            }

        }
        static float Decode<T>(T code, float scale, float offset)
        {
            if (Convert.ToSingle(code.ToString()) >= 2 && Convert.ToSingle(code.ToString()) <= 1023)
            {
                float value = (Convert.ToSingle(code.ToString()) - offset) / scale;
                return value;
            }
            else
            {
                float value = -999;
                return value;
            }
        }
        static float Decode(byte code, float scale, float offset)
        {
            if (code >= 2 && code <= 255)
            {
                float value = (code - offset) / scale;
                return value;
            }
            else
            {
                float value = -999;
                return value;
            }
        }
        static float DecodeUInt16(BigEndianUInt16 code, float scale, float offset)
        {
            if (code >= 2 && code <= 1023)
            {
                float value = (code - offset) / scale;
                return value;
            }
            else
            {
                float value = -999;
                return value;
            }
        }
        private T ReadStructure<T>(FileStream fs)
        {
            int size1 = Marshal.SizeOf(typeof(T));
            byte[] bytes1 = new byte[size1];
            IntPtr ptr1 = Marshal.AllocHGlobal(size1);
            fs.Read(bytes1, 0, size1);
            Marshal.Copy(bytes1, 0, ptr1, size1);
            T structure = (T)Marshal.PtrToStructure(ptr1, typeof(T));
            Marshal.FreeHGlobal(ptr1);
            return structure;
        }

        static double dTimeTotal_ReadStructure = 0;
        private T ReadStructure<T>(BZip2InputStream bzip2Stream)
        {
            DateTime dt1 = DateTime.Now;
            int size = Marshal.SizeOf(typeof(T));
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            bzip2Stream.Read(bytes, 0, size);
            Marshal.Copy(bytes, 0, ptr, size);
            T structure = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            dTimeTotal_ReadStructure += ts.TotalMilliseconds;
            return structure;
        }
        static double dTimeTotal_ReadMoment = 0;
        private T ReadMoment<T>(BZip2InputStream bzip2Stream, int binGates)
        {
            DateTime dt1 = DateTime.Now;
            int size = binGates;
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            bzip2Stream.Read(bytes, 0, size);
            Marshal.Copy(bytes, 0, ptr, size);
            T moment = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            dTimeTotal_ReadMoment += ts.TotalMilliseconds;
            return moment;

        }
        private double SwitchResolution(byte i)
        {
            double azResoultion = 0;
            switch (i)
            {
                case 1:
                    azResoultion = 0.5;
                    break;
                case 2:
                    azResoultion = 1;
                    break;
                default:
                    break;
            }
            return azResoultion;
        }


        private int SwitchDataBlock(BigEndianUInt16 i)
        {
            int momentCount = 0;
            switch (i)
            {
                case 6:
                    momentCount = 3;
                    break;
                case 7:
                    momentCount = 4;
                    break;
                case 9:
                    momentCount = 6;

                    break;
                default:
                    break;
            }
            return momentCount;
        }
        private List<List<int>> Sort(float[,] azimuth)
        {
            List<List<int>> sorted = new List<List<int>>();
            for (int i = 0; i < azimuth.GetLength(0); i++)
            {
                List<float> list = new List<float>();
                List<float> backUp = new List<float>();
                List<int> sortIndex = new List<int>();
                for (int j = 0; j < azimuth.GetLength(1); j++)
                {
                    list.Add(azimuth[i, j]);
                    backUp.Add(azimuth[i, j]);
                }
                list.Sort();
                for (int j = 0; j < list.Count; j++)
                {
                    sortIndex.Add(backUp.IndexOf(list[j]));
                }
                sorted.Add(sortIndex);
            }
            return sorted;
        }
        private float[,,] Reset(string str, List<List<int>> sorted, float[,,] val)
        {
            float[,,] sort = DataInitial<float>.GetResult(9, 720, val.GetLength(2), -999);
            List<int> layer = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            switch (str)
            {
                case "REF":
                case "PHI":
                case "RHO":
                case "ZDR":
                    //int[] layer = {0,2,4,5,6,7,8,9,10};
                    layer.Remove(1);
                    layer.Remove(3);
                    foreach (int i in layer)
                    {
                        var list = sorted[i];
                        if (i == 0 || i == 2)
                        {
                            for (int j = 0; j < 720; j++)
                            {
                                for (int k = 0; k < val.GetLength(2); k++)
                                {
                                    sort[i / 2, j, k] = val[i, list[j], k];
                                }
                            }
                        }
                        else if (i > 3)
                        {
                            for (int j = 0; j < 360; j++)
                            {
                                for (int k = 0; k < val.GetLength(2); k++)
                                {
                                    sort[i - 2, j, k] = val[i, list[j], k];
                                }
                            }
                        }
                    }
                    break;
                case "VEL":
                case "SW ":
                    layer.Remove(0);
                    layer.Remove(2);
                    foreach (int i in layer)
                    {
                        var list = sorted[i];
                        if (i == 1 || i == 3)
                        {
                            for (int j = 0; j < 720; j++)
                            {
                                for (int k = 0; k < val.GetLength(2); k++)
                                {
                                    sort[(i - 1) / 2, j, k] = val[i, list[j], k];
                                }
                            }
                        }
                        else if (i > 3)
                        {
                            for (int j = 0; j < 360; j++)
                            {
                                for (int k = 0; k < val.GetLength(2); k++)
                                {
                                    sort[i - 2, j, k] = val[i, list[j], k];
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return sort;
        }

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
        private float[] DataInitial(int i, float value)
        {
            float[] outData = new float[i];
            for (int layer = 0; layer < i; layer++)
            {
                outData[layer] = value;
            }
            return outData;
        }

        public DprRdaData ReadData(string filePath, frmProgress frmpg)
        {
            //float[, ,] DBZ = DataInitial<float>.GetResult(11, 720, 1840, -999);
            //float[, ,] VEL = DataInitial<float>.GetResult(11, 720, 1200, -999);
            //float[, ,] SW = DataInitial<float>.GetResult(11, 720, 1200, -999);
            //float[, ,] ZDR = DataInitial<float>.GetResult(11, 720, 1200, -999);
            //float[, ,] PHI = DataInitial<float>.GetResult(11, 720, 1200, -999);
            //float[, ,] RHO = DataInitial<float>.GetResult(11, 720, 1200, -999);
            //float[, ,] KDP = DataInitial<float>.GetResult(9, 720, 1200, -999);
            //float[] ElevationData = DataInitial<float>.GetResult(11, -999);
            //float[, ,] dbz = DataInitial<float>.GetResult(9, 720, 1840, -999);
            //float[, ,] vel = DataInitial<float>.GetResult(9, 720, 1200, -999);
            //float[, ,] sw  = DataInitial<float>.GetResult(9, 720, 1200, -999);
            //float[, ,] zdr = DataInitial<float>.GetResult(9, 720, 1200, -999);
            //float[, ,] phi = DataInitial<float>.GetResult(9, 720, 1200, -999);
            //float[, ,] rho = DataInitial<float>.GetResult(9, 720, 1200, -999);
            //float[, ,] kdp = DataInitial<float>.GetResult(9, 720, 1200, -999);
            float[,,] DBZ = DataInitial(11, 720, 1200, -999);
            float[,,] VEL = DataInitial(11, 720, 1200, -999);
            float[,,] SW = DataInitial(11, 720, 1200, -999);
            float[,,] ZDR = DataInitial(11, 720, 1200, -999);
            float[,,] PHI = DataInitial(11, 720, 1200, -999);
            float[,,] RHO = DataInitial(11, 720, 1200, -999);
            float[,,] KDP = DataInitial(9, 720, 1200, -999);
            float[] ElevationData = DataInitial(11, -999);
            float[,,] dbz = DataInitial(9, 720, 1200, -999);
            float[,,] vel = DataInitial(9, 720, 1200, -999);
            float[,,] sw = DataInitial(9, 720, 1200, -999);
            float[,,] zdr = DataInitial(9, 720, 1200, -999);
            float[,,] phi = DataInitial(9, 720, 1200, -999);
            float[,,] rho = DataInitial(9, 720, 1200, -999);
            float[,,] kdp = DataInitial(9, 720, 1200, -999);

            float[] azimuthAngle = new float[720];
            float azimuthNumber = 0;

            string dataSwitch = filePath.Substring(filePath.Length - 3);
            DateTime t1 = DateTime.Now;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (BZip2InputStream bzip2Stream = new BZip2InputStream(fs))
                {
                    float[,] azimuth = DataInitial<float>.GetResult(11, 720, 999);
                    bzip2Stream.Read(new byte[24 + 325888], 0, 24 + 325888);
                    try
                    {

                        int radialStatus = 0;
                        while (radialStatus != 4)
                        {
                            int azIndex = 0;
                            do
                            {
                                //*****Message Header Data *****///
                                MessageHeader sizeMessHeader =
                                    ReadStructure<MessageHeader>(bzip2Stream);

                                //*****Radar Data Generic Format Blocks ***//                                           
                                GenericFormatBlock genericFormatBlock =
                                    ReadStructure<GenericFormatBlock>(bzip2Stream);

                                //****Volume Data Contant Type*****//                                         
                                VolumeDataConstantType volumeDataConstantType =
                                                        ReadStructure<VolumeDataConstantType>(bzip2Stream);

                                //****Elevation Data Constant Type *****//
                                ElevationDataConstantType elevationDataCostantType =
                                                            ReadStructure<ElevationDataConstantType>(bzip2Stream);

                                //***Radial Data Block *****//                                           
                                RadialDataConstantType radialDataConstantType =
                                                        ReadStructure<RadialDataConstantType>(bzip2Stream);
                                int elIndex = genericFormatBlock.elevNum - 1;
                                double azResoultion = SwitchResolution(genericFormatBlock.azReSp);
                                azimuth[elIndex, azIndex] = genericFormatBlock.azAngle;
                                azimuthNumber = genericFormatBlock.azimuthNum;
                                radialStatus = genericFormatBlock.radStatus;
                                ElevationData[elIndex] = genericFormatBlock.elevAngle;

                                int momentCount =
                                    SwitchDataBlock(genericFormatBlock.dataBlockCount);

                                frmpg.nProgress = (int)(bzip2Stream.Position / (double)bzip2Stream.Length * 100 * 0.4);

                                for (int i = 0; i < momentCount; i++)
                                {
                                    DescripOfDataMomentType descripOfDataMomentType =
                                        ReadStructure<DescripOfDataMomentType>(bzip2Stream);
                                    string typeStr = new string(descripOfDataMomentType.dataMomentName);
                                    uint binGates = descripOfDataMomentType.numberOfDataMomentGates;
                                    float scale = descripOfDataMomentType.scaLe;
                                    float offset = descripOfDataMomentType.offset;
                                    int nSize = 0;
                                    switch (typeStr)
                                    {

                                        case "REF":
                                            nSize = (int)binGates;
                                            byte[] mDBZ = new byte[nSize];
                                            bzip2Stream.Read(mDBZ, 0, nSize);
                                            for (int binNum = 0; binNum < 1192; binNum++)
                                            {
                                                DBZ[elIndex, azIndex, binNum + 8] =
                                                    Decode(mDBZ[binNum], scale, offset);
                                            }
                                            break;

                                        case "VEL":
                                            nSize = (int)binGates;
                                            byte[] mVEL = new byte[nSize];
                                            bzip2Stream.Read(mVEL, 0, nSize);
                                            for (int binNum = 0; binNum < binGates; binNum++)
                                            {
                                                VEL[elIndex, azIndex, binNum + 8] =
                                                    Decode(mVEL[binNum], scale, offset);
                                            }
                                            break;

                                        case "SW ":
                                            nSize = (int)binGates;
                                            byte[] mSW = new byte[nSize];
                                            bzip2Stream.Read(mSW, 0, nSize);
                                            for (int binNum = 0; binNum < binGates; binNum++)
                                            {
                                                SW[elIndex, azIndex, binNum + 8] =
                                                    Decode(mSW[binNum], scale, offset);
                                            }
                                            break;

                                        case "RHO":
                                            nSize = (int)binGates;
                                            byte[] mRHO = new byte[nSize];
                                            bzip2Stream.Read(mRHO, 0, nSize);
                                            for (int binNum = 0; binNum < binGates; binNum++)
                                            {
                                                RHO[elIndex, azIndex, binNum + 8] =
                                                    Decode(mRHO[binNum], scale, offset);
                                            }
                                            break;

                                        case "PHI":
                                            nSize = (int)binGates * 2;
                                            byte[] mPHI = new byte[nSize];
                                            bzip2Stream.Read(mPHI, 0, nSize);
                                            for (int binNum = 0; binNum < binGates; binNum++)
                                            {

                                                PHI[elIndex, azIndex, binNum + 8] =
                                                    DecodeUInt16(mPHI[binNum], scale, offset);
                                            }
                                            break;

                                        case "ZDR":
                                            nSize = (int)binGates;
                                            byte[] mZDR = new byte[nSize];
                                            bzip2Stream.Read(mZDR, 0, nSize);
                                            for (int binNum = 0; binNum < binGates; binNum++)
                                            {
                                                ZDR[elIndex, azIndex, binNum + 8] =
                                                    Decode(mZDR[binNum], scale, offset);
                                            }
                                            break;
                                        default:
                                            break;

                                    }
                                }
                                azIndex = azIndex + 1;

                            } while (radialStatus != 2);

                        }


                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine("雷达数据读取故障！！"); }
                    finally
                    {
                        bzip2Stream.Close();
                    }
                    //**************************内存空间占用490MB*********************************//
                    DateTime t2 = DateTime.Now;
                    var sorted = Sort(azimuth);
                    //Console.WriteLine("ReadStructure函数耗时：" + dTimeTotal_ReadStructure);
                    //Console.WriteLine("ReadMoment函数耗时：" + dTimeTotal_ReadMoment);
                    //Console.WriteLine("以上耗时：" + (t2 - t1).TotalMilliseconds);
                    // 30MB
                    frmpg.nProgress = 40;
                    dbz = Reset("REF", sorted, DBZ);
                    vel = Reset("VEL", sorted, VEL);
                    sw = Reset("SW ", sorted, SW);
                    zdr = Reset("ZDR", sorted, ZDR);
                    rho = Reset("RHO", sorted, RHO);
                    phi = Reset("PHI", sorted, PHI);
                    frmpg.nProgress = 45;

                    DBZ = null;
                    VEL = null;
                    SW = null;
                    ZDR = null;
                    RHO = null;
                    PHI = null;
                    System.GC.Collect();


                    //************************内存空间占用657.4*************************************//

                }
                fs.Close();
            }

            QualityControl qc = new QualityControl(phi, dbz, rho);
            KDP = qc.GetKdpData(frmpg);
            return new DprRdaData(dbz, vel, sw, rho, phi, zdr, KDP, ElevationData);

        }

    }
}
