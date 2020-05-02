using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FactorialOperation : ConvertableSingleOperation
    {
        public FactorialOperation(string numberOperator)
        {
            Operand = numberOperator;
        }
        protected override string ExecuteWithDecimalOperand()
        {
            var numberLimit = int.Parse(Operand);
            var result = 1;
            for (int currentNumber = 1; currentNumber <= numberLimit; currentNumber++)
            {
                result *= currentNumber;
            }
            return result.ToString();
        }
    }
}
