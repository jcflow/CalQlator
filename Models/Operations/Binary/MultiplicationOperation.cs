using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MultiplicationOperation: ConvertableBinaryOperation
    {

        public string FactorA
        {
            get
            {
                return base.FirstOperand;
            }
            set
            {
                base.FirstOperand = value;
            }
        }
        public string FactorB
        {
            get
            {
                return base.SecondOperand;
            }
            set
            {
                base.SecondOperand = value;
            }
        }
        public MultiplicationOperation(string factorA, string factorB)
        {
            FactorA = factorA;
            FactorB = factorB;
        }
        protected override string ExecuteWithConvertedOperands()
        {
            var factorANumber = double.Parse(FactorA);
            var factorBNumber = double.Parse(FactorB);
            var result = factorANumber * factorBNumber;
            return result.ToString();
        }
    }
}
