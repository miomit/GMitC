using System;

namespace GMitC
{
    class Calculator
    {
        double Num = 0;
        public void AddNum(string num)
        {
            
            if (Num == 0)
            {
                Num = Convert.ToInt16(num);
            }
            else
            {
                Num = Num * 10 + Convert.ToInt16(num);
            }
        }

        public void Backspace()
        {
            string num = Num.ToString();
            int nl = num.Length;
            if (nl <= 1)
            {
                Num = 0;
            }
            else
            {
                Num = Convert.ToDouble(num.Remove(nl - 1));
            }
        }

        public void Clean()
        {
            Num = 0;
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