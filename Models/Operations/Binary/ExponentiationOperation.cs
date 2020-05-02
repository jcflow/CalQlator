using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExponentiationOperation : ConvertableBinaryOperation
    {
        public string Base
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
        public string Exponent
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
        public ExponentiationOperation(string baseNumber, string exponent)
        {
            Base = baseNumber;
            Exponent = exponent;
        }

        protected override string ExecuteWithConvertedOperands()
        {
            var baseNumber = double.Parse(Base);
            var exponentNumber = double.Parse(Exponent);
            var result = Math.Pow(baseNumber, exponentNumber);
            return result.ToString();
        }
    }
}
