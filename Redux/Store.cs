namespace Redux.Csharp
{
    using System;

    public class Store<STATE, ACTION, REDUCER> : IStore<STATE, ACTION, REDUCER>
        where STATE : IState
        where ACTION : IReduxAction
        where REDUCER : IReducer<STATE, ACTION>
    {
        private STATE currentState;
        private REDUCER reducer;

        public event EventHandler<STATE> OnStateUpdate;

        public Store(STATE initialState, REDUCER reducer)
        {
            this.currentState = initialState;
            this.reducer = reducer;
        }

        public STATE GetState()
        {
            return this.currentState;
        }

        public void Dispatch(ACTION action)
        {
            lock (this)
            {
                this.currentState = this.reducer.Reduce(this.currentState, action);
                this.OnStateUpdate?.Invoke(this, this.currentState);
            }
        }
    }
}
