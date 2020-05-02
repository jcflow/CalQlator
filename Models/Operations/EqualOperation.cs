using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EqualOperation : IOperation
    {
        public NumericSystemType NumericSystem { get; set; }
        public OperationType Type { get { return OperationType.EQUAL; } }
        public string Dividend { get; set; }
        public string Divisor { get; set; }
        public EqualOperation(string dividend, string divisor)
        {
            Dividend = dividend;
            Divisor = divisor;
        }
        public string Execute()
        {
            return Dividend;
        }
    }
}
