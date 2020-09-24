namespace Counter
{
    class CounterReducer : Redux.IReducer<CounterState, CounterAction>
    {
        public CounterState Reduce(CounterState oldState, CounterAction action)
        {
            switch (action)
            {
                case CounterAction.Increment _inc:
                    return new CounterState(oldState.Value + 1);

                case CounterAction.Decrement _dec:
                    return new CounterState(oldState.Value - 1);
                    
                default:
                    return oldState;
            }
        }
    }
}