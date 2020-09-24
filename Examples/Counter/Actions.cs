namespace Counter
{
    abstract class CounterAction : Redux.IReduxAction {
        public class Increment : CounterAction { };
        public class Decrement : CounterAction { };
    }
}