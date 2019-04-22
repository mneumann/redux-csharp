namespace Examples.Calculator.Tests
{
    using System;
    using Xunit;
    using System.Collections.Generic;
    using Examples.Calculator;

    public class TestCalculator
    {
        private CalculatorStore Store => new CalculatorStore();

        [Fact]
        public void Test_AddingTwoNumbers()
        {
            var store = this.Store;
            store.Dispatch(new CalculatorAction.PushNumberAction(1));
            store.Dispatch(new CalculatorAction.PushNumberAction(2));
            store.Dispatch(new CalculatorAction.AddAction());
            Assert.Equal(new Stack<float>(new List<float> { 3 }), store.GetState().CloneNumberStack());
        }
    }
}
