using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models
{
    public class DisplayableCalculatorController
    {
        #region Private members

        private CalculatorModel calculator;

        /// <summary>
        /// Flag that determinates if the operation needs other operand.
        /// </summary>
        private bool displayRefreshRequired;

        #endregion

        #region Constructors

        public DisplayableCalculatorController()
        {
            calculator = new CalculatorModel();
            displayRefreshRequired = false;
            Display = Constants.ZERO;
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            CurrentOperationType = OperationType.NONE;
            LastOperationType = OperationType.NONE;
            NumericSystem = NumericSystemType.DECIMAL;
        }

        #endregion

        #region  Public properties and methods

        public string Display { get; private set; }

        public OperationType LastOperationType { get; private set; }

        public string FirstOperand
        {
            get { return calculator.FirstOperand; }
            private set { calculator.FirstOperand = value; }
        }

        public string SecondOperand
        {
            get { return calculator.SecondOperand; }
            private set { calculator.SecondOperand = value; }
        }

        public OperationType CurrentOperationType
        {
            get { return calculator.CurrentOperationType; }
            private set { calculator.CurrentOperationType = value; }
        }

        public NumericSystemType NumericSystem
        {
            get { return calculator.NumericSystem; }
            set
            {
                Reset();
                calculator.NumericSystem = value;
            }
        }
        
        public bool CanActionBeExecuted()
        {
            return true;
        }

        /// <summary>
        /// Executes a calculator action.
        /// </summary>
        public void ExecuteAction(ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.CLEAR:
                    Reset();
                    break;
                case ActionType.DELETE:
                    DeleteDigit();
                    break;
                case ActionType.POINT:
                    AppendPoint();
                    break;
                default:
                    throw new CalculatorException("Unknown action type: " + actionType);
            }
            displayRefreshRequired = false;
        }

        public bool CanOperationBeExecuted(OperationType operationType)
        {
            return NumericSystem.IsValidOperation(operationType);
        }

        public bool IsValidDigit(string digit)
        {
            return NumericSystem.isValidDigit(digit);
        }

        public void AppendDigit(string digit)
        {
            if (Display == Constants.ZERO || displayRefreshRequired)
            {
                Display = digit;
            }
            else
            {
                Display += digit;
            }
            displayRefreshRequired = false;
        }

        /// <summary>
        /// Executes an operation that uses two operands and sets its result on Display property.
        /// It will take display content as operand.
        /// If only one operand is available it the operation will be saved until then.
        /// If a valid result is returned it will be took as first operand for consecutive operations.
        /// </summary>
        /// <param name="operationType">The operation type that will be executed.</param>
        public void ExecuteBinaryOperation(OperationType operationType)
        {
            try
            {
                if (FirstOperand == string.Empty || LastOperationType == OperationType.EQUAL)
                {
                    FirstOperand = Display;
                    LastOperationType = operationType;
                }
                else
                {
                    SecondOperand = Display;
                    CurrentOperationType = LastOperationType;
                    calculator.CalculateResult();
                    LastOperationType = operationType;
                    Display = calculator.Result;
                    FirstOperand = Display;
                }
                displayRefreshRequired = true;
            }
            catch (CalculatorException exception)
            {
                Reset();
                throw exception;
            }
        }

        /// <summary>
        /// Executes an operation that uses only a operand and sets its result on Display property.
        /// It will take display content as operand.
        /// If a valid result is returned it will be took as first operand for consecutive operations.
        /// </summary>
        /// <param name="operationType">The operation type that will be executed.</param>
        public void ExecuteSingularOperation(OperationType operationType)
        {
            try { 
                FirstOperand = Display;
                CurrentOperationType = operationType;
                calculator.CalculateResult();
                LastOperationType = OperationType.EQUAL;
                Display = calculator.Result;
                FirstOperand = Display;
                displayRefreshRequired = true;
            }
            catch (CalculatorException exception)
            {
                Reset();
                throw exception;
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Resets the calculator. Including display, operations and operands.
        /// </summary>
        private void Reset()
        {
            Display = Constants.ZERO;
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            CurrentOperationType = OperationType.NONE;
            LastOperationType = OperationType.NONE;
        }

        /// <summary>
        /// Remove last digit of Display property, but keeping zero digit at least.
        /// </summary>
        private void DeleteDigit()
        {
            if (Display.Length > 1)
            {
                Display = Display.Substring(0, Display.Length - 1);
            } else
            {
                Display = Constants.ZERO;
            }
        }

        /// <summary>
        /// Appends a point to Display property.
        /// </summary>
        private void AppendPoint()
        {
            if (displayRefreshRequired)
            {
                Display = Constants.ZERO + Constants.POINT;
            }
            else if (!Display.Contains(Constants.POINT))
            {
                Display += Constants.POINT;
            }
        }

        #endregion
    }
}
