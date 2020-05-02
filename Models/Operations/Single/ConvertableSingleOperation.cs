using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class ConvertableSingleOperation : IOperation
    {
        public NumericSystemType NumericSystem { get; set; }
        public string Operand { get; set; }

        protected ConvertableSingleOperation() { }

        /// <summary>
        /// Executes the single operation, but converting the operand to decimal numeric system and converting the result back.
        /// </summary>
        /// <returns>The result representation on the desired numeric system.</returns>
        public string Execute()
        {
            Operand = NumericSystem.ConvertToDecimal(Operand);
            var result = ExecuteWithDecimalOperand();
            return NumericSystem.ConvertFromDecimal(result);
        }

        /// <summary>
        /// The single operation implementation considering the operand and result on decimal numeric system.
        /// </summary>
        /// <returns>The result representation on decimal numeric system.</returns>
        protected abstract string ExecuteWithDecimalOperand();
    }
}
