namespace Examples.Calculator
{
    using Redux.Csharp;

    public class CalculatorStore : Store<CalculatorState, CalculatorAction, CalculatorReducer>
    {
        public CalculatorStore(CalculatorState initialState, CalculatorReducer reducer) : base(initialState, reducer)
        {
        }
    }
}
