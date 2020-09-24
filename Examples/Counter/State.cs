namespace Counter
{
    class CounterState : Redux.IState {
        public readonly int Value;

        public CounterState(int value) {
            this.Value = value;
        }
    }
}