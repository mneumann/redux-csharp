namespace Examples.Calculator
{
    using System;
    using Redux.Csharp;

    public enum BinaryOperation
    {
        ADD,
        SUB,
        MUL,
        DIV
    }

    public abstract class CalculatorAction : IReduxAction
    {
        public class BinaryOperationAction : CalculatorAction
        {
            public readonly BinaryOperation BinaryOperation;

            public BinaryOperationAction(BinaryOperation binaryOperation)
            {
                this.BinaryOperation = binaryOperation;
            }
        }

        public class EnterAction : CalculatorAction
        {
        }

        public class TypeDotAction : CalculatorAction
        {
        }

        public class TypeDigitAction : CalculatorAction
        {
            public readonly int Digit;
            public TypeDigitAction(int digit)
            {
                this.Digit = (digit >= 0 && digit <= 9) ? digit : throw new ArgumentOutOfRangeException(nameof(digit));
            }
        }
    }
}
