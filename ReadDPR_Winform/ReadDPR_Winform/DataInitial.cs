namespace ReadDPR_Winform
{
    public class DataInitial<T>
    {

        private T valueInvalid;

        public static T[] GetResult(int ii, T valueInvalid)
        {
            T[] outData = new T[ii];
            for (int i = 0; i < ii; i++)
            {
                outData[i] = valueInvalid;
            }
            return outData;
        }
        public static T[,,] GetResult(int ii, int jj, int kk, T valueInvalid)
        {
            T[,,] outData = new T[ii, jj, kk];
            for (int i = 0; i < ii; i++)
            {
                for (int j = 0; j < jj; j++)
                {
                    for (int k = 0; k < kk; k++)
                    {
                        outData[i, j, k] = valueInvalid;
                    }
                }
            }
            return outData;
        }
        public static T[,] GetResult(int ii, int jj, T valueInvalid)
        {
            T[,] outData = new T[ii, jj];
            for (int i = 0; i < ii; i++)
            {
                for (int j = 0; j < jj; j++)
                {
                    outData[i, j] = valueInvalid;
                }
            }
            return outData;
        }

    }
}
