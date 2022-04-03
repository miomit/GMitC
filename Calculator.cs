using System;

namespace GMitC
{
    class Calculator
    {
        private ICalDuo Operation;

        public void SetOperation(ICalDuo operation) => Operation = operation;
        public double CalRes(double a, double b) => Operation.Calculate(a, b);
        public double CalResUno(ICalUno op, double a) => op.Calculate(a);
    }
    
}