namespace GMitC
{
    public class Div : ICalDuo
    {
        public double Calculate(double a, double b) => System.Math.Round(a / b, 2);
    }
}