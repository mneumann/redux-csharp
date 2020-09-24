namespace Examples.Calculator
{
    using System;
    using Redux;

    public abstract class CalculatorAction : IReduxAction
    {
        public class PushNumberAction : CalculatorAction
        {
            public readonly float Number;

            public PushNumberAction(float number)
            {
                this.Number = number;
            }
        }

        public class PopNumberAction : CalculatorAction
        {
        }

        public class AddAction : CalculatorAction
        {
        }

        public class SubAction : CalculatorAction
        {
        }

        public class MulAction : CalculatorAction
        {
        }

        public class DivAction : CalculatorAction
        {
        }

    }
}
