using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CalculatorException : Exception
    {
        public CalculatorException(string message) : base(message)
        {
        }

        public CalculatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
