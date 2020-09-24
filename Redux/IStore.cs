namespace Redux
{
    using System;

    public interface IStore<STATE, ACTION, REDUCER>
        where STATE : IState
        where ACTION : IReduxAction
        where REDUCER : IReducer<STATE, ACTION>
    {
        /// Event triggered when state was "updated".
        event EventHandler<STATE> OnStateChanged;

        /// Read the current state. As state is immutable, it is safe to "read" it at any time without locking..
        STATE GetState();

        /// This dispatches an action which will transform the state as a consequence of the action.
        /// There is no guarantee whether this method is blocking or not.
        void Dispatch(ACTION action);
    }
}
