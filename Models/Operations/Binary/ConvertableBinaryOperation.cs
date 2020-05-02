using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class ConvertableBinaryOperation : IOperation
    {
        public NumericSystemType NumericSystem { get; set; }
        public string FirstOperand { get; set; }
        public string SecondOperand { get; set; }

        protected ConvertableBinaryOperation() { }

        /// <summary>
        /// Executes the binary operation, but converting the two operands to decimal numeric system and converting the result back.
        /// </summary>
        /// <returns>The result representation on the desired numeric system.</returns>
        public string Execute()
        {
            ConvertOperands();
            var result = ExecuteWithConvertedOperands();
            return NumericSystem.ConvertFromDecimal(result);
        }

        /// <summary>
        /// The binary operation implementation considering the two operands and result on decimal numeric system.
        /// </summary>
        /// <returns>The result representation on decimal numeric system.</returns>
        protected abstract string ExecuteWithConvertedOperands();

        private void ConvertOperands()
        {
            FirstOperand = NumericSystem.ConvertToDecimal(FirstOperand);
            SecondOperand = NumericSystem.ConvertToDecimal(SecondOperand);
        }
    }
}
