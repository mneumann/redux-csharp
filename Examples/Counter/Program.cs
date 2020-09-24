using System;
using Redux;

namespace Counter
{
    abstract class CounterAction : IReduxAction {
        public class Increment : CounterAction { };
        public class Decrement : CounterAction { };
    }

    class CounterState : IState {
        public readonly int Value;

        public CounterState(int value) {
            this.Value = value;
        }
    }

    class CounterReducer : IReducer<CounterState, CounterAction>
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

    class MainClass
    {
        public static void Main(string[] args)
        {
            var myStore = new Store<CounterState, CounterAction, CounterReducer>(new CounterState(0), new CounterReducer());

            Console.WriteLine("State: {0}", myStore.GetState().Value);

            var state = myStore.GetState();
            myStore.Dispatch(new CounterAction.Increment());
            myStore.Dispatch(new CounterAction.Increment());

            Console.WriteLine("State: {0}", state.Value);
            Console.WriteLine("State: {0}", myStore.GetState().Value);
        }
    }
}
