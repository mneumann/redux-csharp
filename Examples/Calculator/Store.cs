namespace Examples.Calculator
{
    using Redux.Csharp;

    public class CalculatorStore : Store<CalculatorState, CalculatorAction, CalculatorReducer>
    {
        public CalculatorStore() : base(new CalculatorState(), new CalculatorReducer()) { }
        public CalculatorStore(CalculatorState initialState, CalculatorReducer reducer) : base(initialState, reducer)
        {
        }
    }
}
