using System;
using System.Collections.Generic;

namespace Models
{
    public class CalculatorModel
    {
        #region Private members

        private IList<string> operands;

        #endregion

        #region Constructors
        public CalculatorModel()
        {
            InitializeOperands();
            Result = string.Empty;
            CurrentOperationType = OperationType.NONE;
            NumericSystem = NumericSystemType.DECIMAL;
        }

        #endregion

        #region Public properties and methods

        public string FirstOperand
        {
            get { return operands[0]; }
            set { operands[0] = value; }
        }
        public string SecondOperand
        {
            get { return operands[1]; }
            set { operands[1] = value; }
        }

        public OperationType CurrentOperationType { get; set; }
        public string Result { get; private set; }

        public NumericSystemType NumericSystem { get; set; }

        /// <summary>
        /// Returns the operation validated result based on the respective numeric system and operands.
        /// </summary>
        public void CalculateResult()
        {
            ValidateOperationType();
            var operation = OperationFactory.CreateOperationFromType(CurrentOperationType, operands);
            operation.NumericSystem = NumericSystem;
            var newResult = operation.Execute();
            ValidateResult(newResult);
            Result = newResult;
        }
        #endregion

        #region Private methods
        private void ValidateOperationType()
        {
            if (CurrentOperationType == OperationType.NONE)
            {
                throw new CalculatorException("Invalid operation: " + CurrentOperationType);
            }
        }
        private void ValidateResult(string newResult)
        {
            if (newResult == null || newResult == string.Empty || newResult == Constants.NAN)
            {
                throw new CalculatorException("Invalid result of operation.");
            }
        }

        private void InitializeOperands()
        {
            operands = new List<string>();
            // Default first operand
            operands.Add(string.Empty);
            // Default second operand
            operands.Add(string.Empty);
        }
        #endregion
    }
}
