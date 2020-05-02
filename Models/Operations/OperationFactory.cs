using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class OperationFactory
    {
        /// <summary>
        /// Creates a new operation instance from the respective type and the given operands.
        /// </summary>
        public static IOperation CreateOperationFromType(OperationType operationType, IList<string> operands)
        {
            switch (operationType)
            {
                case OperationType.SUM:
                    return new SumOperation(operands[0], operands[1]);
                case OperationType.SUBTRACTION:
                    return new SubtractionOperation(operands[0], operands[1]);
                case OperationType.MULTIPLICATION:
                    return new MultiplicationOperation(operands[0], operands[1]);
                case OperationType.DIVISION:
                    return new DivisionOperation(operands[0], operands[1]);
                case OperationType.EXPONENTIATION:
                    return new ExponentiationOperation(operands[0], operands[1]);
                case OperationType.RADICAL:
                    return new RadicalOperation(operands[0], operands[1]);
                case OperationType.FACTORIAL:
                    return new FactorialOperation(operands[0]);
                case OperationType.CHANGE_SIGN:
                    return new ChangeSignOperation(operands[0]);
                case OperationType.POSITION:
                    return new PositionOperation(operands[0]);
                case OperationType.INVERSE:
                    return new InverseOperation(operands[0]);
                default:
                    throw new CalculatorException("Unknown operation type: " + operationType);
            }
        }
    }
}
