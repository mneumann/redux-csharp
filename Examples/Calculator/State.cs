namespace Examples.Calculator
{
    using Redux;
    using System;
    using System.Collections.Generic;

    public class CalculatorState : IState
    {
        private readonly Stack<float> numberStack;

        public CalculatorState(Stack<float> numberStack)
        {
            this.numberStack = numberStack ?? throw new ArgumentNullException(nameof(numberStack));
        }

        public Stack<float> CloneNumberStack() => new Stack<float>(this.numberStack);

        public CalculatorState()
        {
            this.numberStack = new Stack<float>();
        }
    }
}
