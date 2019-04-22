namespace Examples.Calculator
{
    using System;
    using Redux.Csharp;
    using System.Collections.Generic;

    public class CalculatorReducer : IReducer<CalculatorState, CalculatorAction>
    {
        public CalculatorState Reduce(CalculatorState oldState, CalculatorAction action)
        {
            switch (action)
            {
                case CalculatorAction.PushNumberAction pushNumberAction:
                    {
                        var newNumberStack = oldState.CloneNumberStack();
                        newNumberStack.Push(pushNumberAction.Number);
                        return new CalculatorState(newNumberStack);
                    }

                case CalculatorAction.PopNumberAction popNumberAction:
                    {
                        var newNumberStack = oldState.CloneNumberStack();
                        newNumberStack.Pop();
                        return new CalculatorState(newNumberStack);
                    }

                case CalculatorAction.AddAction addAction:
                    return this.ApplyBinaryOp(oldState, (a, b) => a + b);
                case CalculatorAction.SubAction subAction:
                    return this.ApplyBinaryOp(oldState, (a, b) => a - b);
                case CalculatorAction.MulAction mulAction:
                    return this.ApplyBinaryOp(oldState, (a, b) => a * b);
                case CalculatorAction.DivAction divAction:
                    return this.ApplyBinaryOp(oldState, (a, b) => a / b);
                default:
                    return oldState;
            }
        }

        private CalculatorState ApplyBinaryOp(CalculatorState oldState, Func<float, float, float> operation)
        {
            var newNumberStack = oldState.CloneNumberStack();
            var arg2 = newNumberStack.Pop();
            var arg1 = newNumberStack.Pop();
            newNumberStack.Push(operation.Invoke(arg1, arg2));
            return new CalculatorState(newNumberStack);
        }
    }
}
