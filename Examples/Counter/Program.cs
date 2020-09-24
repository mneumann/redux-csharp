
namespace Counter
{
    using System;

    class MainClass
    {
        public static void Main(string[] args)
        {
            var myStore = new Redux.Store<CounterState, CounterAction, CounterReducer>(new CounterState(0), new CounterReducer());

            Console.WriteLine("State: {0}", myStore.GetState().Value);

            var state = myStore.GetState();
            myStore.Dispatch(new CounterAction.Increment());
            myStore.Dispatch(new CounterAction.Increment());

            Console.WriteLine("State: {0} (look it's immutable!)", state.Value);
            Console.WriteLine("State: {0}", myStore.GetState().Value);
        }
    }
}