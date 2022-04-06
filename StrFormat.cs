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

        public static string RemoveEnd(ref double num)
        {
            string numStr = num.ToString();
            int nl = numStr.Length;

            if (nl <= 1)
            {
                numStr = "0";
            }
            else
            {
                numStr = numStr.Remove(nl - 1);
            }
            
            num = Convert.ToDouble(numStr);

            return numStr;
        }

        public static string AddEnd(ref double num, string val, bool isDot)
        {
            if (num == 0)
            {
                if (isDot)
                    num = Convert.ToDouble("0," + val);
                else
                    num = Convert.ToDouble(val);
            }
            else
            {
                if (isDot)
                {
                    if (!num.ToString().Contains(","))
                    {
                        num = Convert.ToDouble(num.ToString() + "," + val);
                    }
                    else
                    {
                        num = Convert.ToDouble(num.ToString() + val);
                    }
                }
                else
                {
                    num = num * 10 + Convert.ToInt16(val);
                }
            }

            return num.ToString();
        }
    }
}