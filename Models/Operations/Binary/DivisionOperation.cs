using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DivisionOperation: ConvertableBinaryOperation
    {
        public string Dividend
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
        public string Divisor
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
        public DivisionOperation(string dividend, string divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }

        protected override string ExecuteWithConvertedOperands()
        {
            var dividendNumber = double.Parse(Dividend);
            var divisorNumber = double.Parse(Divisor);
            var result = dividendNumber / divisorNumber;
            return result.ToString();
        }
    }
}
