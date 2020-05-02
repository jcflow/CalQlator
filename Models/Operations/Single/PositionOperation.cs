using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PositionOperation : ConvertableSingleOperation
    {
        public PositionOperation(string numberOperand)
        {
            Operand = numberOperand;
        }

        protected override string ExecuteWithDecimalOperand()
        {
            var operandNumber = double.Parse(Operand);
            var result = 1 / operandNumber;
            return result.ToString();
        }
    }
}
