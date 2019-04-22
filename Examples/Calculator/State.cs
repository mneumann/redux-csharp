namespace Examples.Calculator
{
    using Redux.Csharp;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class CalculatorState : IState
    {
        public readonly string CurrentNumberString;
        public readonly Stack<float> NumberStack;

        // public ReadOnlyCollection<float> NumberStack => this.numberStack.AsReadOnly();
        public Stack<float> CloneNumberStack() => new Stack<float>(this.NumberStack);

        public float CurrentNumber => float.Parse(this.CurrentNumberString, CultureInfo.InvariantCulture);
        // public float TopOfNumberStack => this.numberStack[this.numberStack.Count - 1];

        public CalculatorState()
        {
            this.CurrentNumberString = "";
            this.NumberStack = new Stack<float>();
        }

        public CalculatorState(string currentNumberString, Stack<float> numberStack)
        {
            this.CurrentNumberString = currentNumberString ?? throw new ArgumentNullException(nameof(currentNumberString));
            this.NumberStack = numberStack ?? throw new ArgumentNullException(nameof(numberStack));
        }
    }
}
