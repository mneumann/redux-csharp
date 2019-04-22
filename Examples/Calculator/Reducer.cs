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
                case CalculatorAction.EnterAction enterAction:
                    {
                        var newNumberStack = oldState.CloneNumberStack();
                        if (oldState.CurrentNumberString.Length > 0)
                        {
                            newNumberStack.Push(oldState.CurrentNumber);
                        }
                        return new CalculatorState("", newNumberStack);
                    }

                case CalculatorAction.BinaryOperationAction binaryOperationAction:
                    {
                        var newNumberStack = oldState.CloneNumberStack();
                        if (oldState.CurrentNumberString.Length > 0)
                        {
                            newNumberStack.Push(oldState.CurrentNumber);
                        }
                        var arg2 = newNumberStack.Pop();
                        var arg1 = newNumberStack.Pop();
                        switch (binaryOperationAction.BinaryOperation)
                        {
                            case BinaryOperation.ADD:
                                newNumberStack.Push(arg1 + arg2);
                                break;
                            case BinaryOperation.SUB:
                                newNumberStack.Push(arg1 - arg2);
                                break;
                            case BinaryOperation.MUL:
                                newNumberStack.Push(arg1 * arg2);
                                break;
                            case BinaryOperation.DIV:
                                newNumberStack.Push(arg1 / arg2);
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                        return new CalculatorState("", newNumberStack);
                    }

                case CalculatorAction.TypeDotAction typeDotAction:
                    {
                        if (oldState.CurrentNumberString.EndsWith("."))
                        {
                            throw new NotSupportedException();
                        }
                        return new CalculatorState(
                                oldState.CurrentNumberString + ".",
                                oldState.NumberStack);
                    }

                case CalculatorAction.TypeDigitAction typeDigitAction:
                    {
                        return new CalculatorState(
                                oldState.CurrentNumberString + typeDigitAction.Digit.ToString(),
                                oldState.NumberStack);
                    }

                default:
                    return oldState;
            }

        }
    }
}
