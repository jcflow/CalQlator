import string
from clr import Models

DIGITS = tuple([('pushButton_n%s' % number, str(number)) for number in range(0, 10)] +
               [('pushButton_%s' % letter, letter.upper()) for letter in string.ascii_lowercase[:6]])
SINGLE_OPERATIONS = (('pushButton_factorial', Models.OperationType.FACTORIAL),
                     ('pushButton_cs', Models.OperationType.CHANGE_SIGN),
                     ('pushButton_position', Models.OperationType.POSITION),
                     ('pushButton_inverse', Models.OperationType.INVERSE))
BINARY_OPERATIONS = (('pushButton_radical', Models.OperationType.RADICAL),
                    ('pushButton_exponentiation', Models.OperationType.EXPONENTIATION),
                    ('pushButton_division', Models.OperationType.DIVISION),
                    ('pushButton_product', Models.OperationType.MULTIPLICATION),
                    ('pushButton_subtraction', Models.OperationType.SUBTRACTION),
                    ('pushButton_plus', Models.OperationType.SUM),
                    ('pushButton_equal', Models.OperationType.EQUAL))
ACTIONS = (('pushButton_clear', Models.ActionType.CLEAR),
           ('pushButton_back', Models.ActionType.DELETE),
           ('pushButton_point', Models.ActionType.POINT))
NUMERIC_SYSTEMS = (('radioButton_binary', Models.NumericSystemType.BINARY),
                   ('radioButton_octal', Models.NumericSystemType.OCTAL),
                   ('radioButton_decimal', Models.NumericSystemType.DECIMAL),
                   ('radioButton_hexadecimal', Models.NumericSystemType.HEXADECIMAL))