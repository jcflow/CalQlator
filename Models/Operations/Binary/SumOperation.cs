using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SumOperation: ConvertableBinaryOperation
    {
        public string AddendA
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
        public string AddendB
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
        public SumOperation(string addendA, string addendB)
        {
            AddendA = addendA;
            AddendB = addendB;
        }
        protected override string ExecuteWithConvertedOperands()
        {
            var addendANumber = double.Parse(AddendA);
            var addendBNumber = double.Parse(AddendB);
            var result = addendANumber + addendBNumber;
            return result.ToString();
        }
    }
}
