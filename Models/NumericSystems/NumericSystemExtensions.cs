using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public static class NumericSystemExtensions
    {
        /// <summary>
        /// Returns the number of the base based on the numeric system.
        /// </summary>
        public static int GetBaseRepresentation(this NumericSystemType numericSystemType)
        {
            switch (numericSystemType)
            {
                case NumericSystemType.BINARY:
                    return 2;
                case NumericSystemType.OCTAL:
                    return 8;
                case NumericSystemType.DECIMAL:
                    return 10;
                case NumericSystemType.HEXADECIMAL:
                    return 16;
                default:
                    throw new CalculatorException("Unknown numeric system: " + numericSystemType);
            }
        }

        /// <summary>
        /// Validate that the operation is valid based on the numeric system type.
        /// </summary>
        public static bool IsValidOperation(this NumericSystemType numericSystemType, OperationType operationType)
        {
            if (operationType == OperationType.INVERSE)
            {
                return numericSystemType == NumericSystemType.BINARY;
            }
            return true;
        }

        /// <summary>
        /// Converts a number on a specfic numeric base to decimal numeric base.
        /// </summary>
        public static string ConvertToDecimal(this NumericSystemType currentSystemType, string number)
        {
            if (currentSystemType == NumericSystemType.DECIMAL)
            {
                return number;
            }
            var baseNumber = currentSystemType.GetBaseRepresentation();
            return Convert.ToInt64(number, baseNumber).ToString();
        }

        /// <summary>
        /// Converts a number from decimal number to its representation on other numeric system base.
        /// </summary>
        public static string ConvertFromDecimal(this NumericSystemType currentSystemType, string number)
        {
            if (currentSystemType == NumericSystemType.DECIMAL)
            {
                return number;
            }
            var baseNumber = currentSystemType.GetBaseRepresentation();
            return Convert.ToString(Convert.ToInt64(number), baseNumber);
        }

        /// <summary>
        /// Validate if the digit exists on the numeric system.
        /// </summary>
        public static bool isValidDigit(this NumericSystemType numericSystem, string digit)
        {
            string pattern = null;
            switch (numericSystem)
            {
                case NumericSystemType.BINARY:
                    pattern = @"[0-1]";
                    break;
                case NumericSystemType.OCTAL:
                    pattern = @"[0-7]";
                    break;
                case NumericSystemType.DECIMAL:
                    pattern = @"[0-9]";
                    break;
                case NumericSystemType.HEXADECIMAL:
                    pattern = @"[0-9a-fA-F]";
                    break;
                default:
                    var message = string.Format("Digit {0} is not supported on current system: {1}", digit, numericSystem);
                    throw new CalculatorException(message);
            }

            Match match = Regex.Match(digit, pattern, RegexOptions.IgnoreCase);
            return match.Success;
        }
    }
}
