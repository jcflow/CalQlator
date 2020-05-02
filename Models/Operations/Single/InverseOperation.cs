using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class InverseOperation : IOperation
    {
        public NumericSystemType NumericSystem { get; set; }
        public string Operand { get; set; }
        public InverseOperation(string numberOperand)
        {
            Operand = numberOperand;
        }
        public string Execute()
        {
            if (NumericSystem != NumericSystemType.BINARY)
            {
                throw new CalculatorException("Inverse operation is not valid on numeric system type: " + NumericSystem);
            }
            var auxiliarCharacter = "?";
            return Operand.Replace("0", auxiliarCharacter).Replace("1", "0").Replace(auxiliarCharacter, "1");
        }
    }
}
