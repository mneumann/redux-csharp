namespace Redux.Csharp
{
    using System;

    public interface IStore<STATE, ACTION, REDUCER>
        where STATE : IState
        where ACTION : IReduxAction
        where REDUCER : IReducer<STATE, ACTION>
    {
        /// Event triggered when state was "updated".
        event EventHandler<STATE> OnStateUpdate;

        /// Read the current state. As state is immutable, it is safe to "read" it at any time without locking..
        STATE GetState();

        /// This dispatches an action which will transform the state.
        void Dispatch(ACTION action);
    }
}
