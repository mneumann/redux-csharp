namespace Examples.Calculator.Tests
{
    using System;
    using Xunit;
    using System.Collections.Generic;
    using Examples.Calculator;

    public class TestCalculator
    {
        private CalculatorStore Store => new CalculatorStore(new CalculatorState(), new CalculatorReducer());

        [Fact]
        public void Test_TypingNumbers()
        {
            var store = this.Store;
            store.Dispatch(new CalculatorAction.TypeDigitAction(1));
            Assert.Equal("1", store.GetState().CurrentNumberString);
            Assert.Equal(1, store.GetState().CurrentNumber);

            store.Dispatch(new CalculatorAction.TypeDigitAction(2));
            Assert.Equal("12", store.GetState().CurrentNumberString);
            Assert.Equal(12, store.GetState().CurrentNumber);

            store.Dispatch(new CalculatorAction.TypeDigitAction(3));
            Assert.Equal("123", store.GetState().CurrentNumberString);
            Assert.Equal(123, store.GetState().CurrentNumber);

            store.Dispatch(new CalculatorAction.TypeDotAction());
            Assert.Equal("123.", store.GetState().CurrentNumberString);
            Assert.Equal(123, store.GetState().CurrentNumber);

            store.Dispatch(new CalculatorAction.TypeDigitAction(3));
            Assert.Equal("123.3", store.GetState().CurrentNumberString);
            Assert.True(Math.Abs(123.3 - store.GetState().CurrentNumber) < 0.01);
        }

        [Fact]
        public void Test_AddingTwoNumbers()
        {
            var store = this.Store;
            store.Dispatch(new CalculatorAction.TypeDigitAction(1));
            store.Dispatch(new CalculatorAction.TypeDigitAction(2));
            store.Dispatch(new CalculatorAction.EnterAction());

            store.Dispatch(new CalculatorAction.TypeDigitAction(3));
            store.Dispatch(new CalculatorAction.TypeDigitAction(0));
            store.Dispatch(new CalculatorAction.EnterAction());

            store.Dispatch(new CalculatorAction.BinaryOperationAction(BinaryOperation.ADD));

            Assert.Equal("", store.GetState().CurrentNumberString);
            Assert.Equal(new Stack<float>(new List<float> { 42 }), store.GetState().NumberStack);
        }
    }
}
