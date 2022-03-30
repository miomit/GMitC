using System;

namespace GMitC
{
    class Calculator
    {
        double Num = 0;
        public string AddNum(string num)
        {
            
            if (Num == 0)
            {
                Num = Convert.ToInt16(num);
            }
            else
            {
                Num = Num * 10 + Convert.ToInt16(num);
            }
            
            return GetNum();
        }

        public string GetNum()
        {
            string num = Num.ToString();
            int nl = num.Length;
            for (int i = 3; i <= nl - (nl % 3); i += 3)
            {
                num = num.Insert(nl - i, " ");
            }
            return num;
        }
    }
    
}