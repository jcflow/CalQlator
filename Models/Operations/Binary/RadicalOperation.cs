using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RadicalOperation : ConvertableBinaryOperation
    {
        public string Index
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
        public string Radicand
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
        public RadicalOperation(string radicand, string index)
        {
            Radicand = radicand;
            Index = index;
        }

        protected override string ExecuteWithConvertedOperands()
        {
            var radicandNumber = double.Parse(Radicand);
            var indexNumber = double.Parse(Index);
            var result = Math.Pow(radicandNumber, (1 / indexNumber));
            return result.ToString();
        }
    }
}
