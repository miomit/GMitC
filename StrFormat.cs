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

        public static string RemoveEnd(in double num)
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
            
            //num = Convert.ToDouble(numStr);

            return numStr;
        }

        public static string AddEnd(in double num, string val, bool isDot)
        {
            if (num == 0)
            {
                if (isDot)
                    return "0," + val;
                else
                    return val;
            }
            else
            {
                if (isDot)
                {
                    if (!num.ToString().Contains(","))
                    {
                        return num.ToString() + "," + val;
                    }
                    else
                    {
                        return num.ToString() + val;
                    }
                }
                else
                {
                    return (num * 10 + Convert.ToInt16(val)).ToString();
                }
            }
        }
    }
}