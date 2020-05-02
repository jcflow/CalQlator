using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SubtractionOperation: ConvertableBinaryOperation
    {

        public string Minuend
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
        public string Subtrahend
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
        public SubtractionOperation(string minuend, string subtrahend)
        {
            Minuend = minuend;
            Subtrahend = subtrahend;
        }
        protected override string ExecuteWithConvertedOperands()
        {
            var minuendNumber = double.Parse(Minuend);
            var subtrahendNumber = double.Parse(Subtrahend);
            var result = minuendNumber - subtrahendNumber;
            return result.ToString();
        }
    }
}
