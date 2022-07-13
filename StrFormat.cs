using System;

namespace GMitC;

static class StrFormat
{
    public static string GetNum(string num)
    {
        int nl;

        if (num.Contains(","))
        {
            int range = num[0] == '-'? num.Length- num.IndexOf(',') - 1 : num.Length - num.IndexOf(',');
            nl = num.Length - range;
        }
        else
        {
            nl = num.Length;
        }

        for 
        (
            int i = num[0] == '-'? 4 : 3;
            i <= nl - (nl % 3); 
            i += 3
        )
        {
            num = num.Insert(nl - i, " ");
        }

        return num;
    }

    public static string RemoveEnd(in string num)
    {
        string numStr = num;
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

    public static string AddEnd(in string num, string val, bool isDot)
    {
        if (Convert.ToDouble(num) == 0)
        {
            if (isDot)
                return num + ',' + val;
            else
                return val;
        }
        else
        {
            if (isDot)
            {
                if (!num.Contains(","))
                {
                    return num + "," + val;
                }
                else
                {
                    return num + val;
                }
            }
            else
            {
                return num + val;
            }
        }
    }
}