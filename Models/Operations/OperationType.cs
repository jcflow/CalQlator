using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum OperationType
    {
        // Operations with two operands
        SUM,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,
        RADICAL,
        EXPONENTIATION,
        EQUAL,

        // Operations with an operand
        FACTORIAL,
        CHANGE_SIGN,
        POSITION,
        INVERSE,

        // Represents an null operation
        NONE
    }
}
