using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChangeSignOperation : ConvertableSingleOperation
    {
        public ChangeSignOperation(string numberOperand)
        {
            Operand = numberOperand;
        }
        
        protected override string ExecuteWithDecimalOperand()
        {
            var operandNumber = double.Parse(Operand);
            var result = operandNumber * -1;
            return result.ToString();
        }
    }
}
