using System;

namespace GMitC
{
    static class StrFormat
    {
        public static string GetNum(string num)
        {
            int nl = num.Length;
            for (int i = 3; i <= nl - (nl % 3); i += 3)
            {
                num = num.Insert(nl - i, " ");
            }
            return num;
        }

        public static double RemoveEnd(string num)
        {
            int nl = num.Length;
            if (nl <= 1)
            {
                num = "0";
            }
            else
            {
                num = num.Remove(nl - 1);
            }
            return Convert.ToDouble(num);
        }

        public static double AddEnd(double num, string val)
        {
            
            if (num == 0)
            {
                num = Convert.ToInt16(val);
            }
            else
            {
                num = num * 10 + Convert.ToInt16(val);
            }

            return num;
        }
    }
}