using System;

namespace GMitC
{
    class Calculator
    {
        private ICalDuo? Operation;
        public bool IsOperation() => Operation is not null;
        public void DelOperation() => Operation = null;
        public void SetOperation(ICalDuo operation) => Operation = operation;
        public double CalRes(double a, double b)
        {
            if (Operation is null)
                return -1;//TODO add error @_@

            return System.Math.Round(Operation.Calculate(a, b), 2);
        }
        public double CalResUno(ICalUno op, double a) => op.Calculate(a);
        public double CalResDuo(ICalDuo op, double a, double b) => op.Calculate(a, b);
    }
    
}