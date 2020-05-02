using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IOperation
    {
        NumericSystemType NumericSystem { get; set; }

        /// <summary>
        /// Returns the result of the operation execution.
        /// </summary>
        string Execute();
    }
}
