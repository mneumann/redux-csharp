namespace Redux
{
    using System;

    public class Store<STATE, ACTION, REDUCER> : IStore<STATE, ACTION, REDUCER>
        where STATE : IState
        where ACTION : IReduxAction
        where REDUCER : IReducer<STATE, ACTION>
    {
        private STATE state;
        private readonly REDUCER reducer;

        public event EventHandler<STATE> OnStateChanged;

        public Store(STATE initialState, REDUCER reducer)
        {
            this.state = initialState;
            this.reducer = reducer;
        }

        public STATE GetState()
        {
            return this.state;
        }

        public void Dispatch(ACTION action)
        {
            lock (this)
            {
                this.state = this.reducer.Reduce(this.state, action);
                this.OnStateChanged?.Invoke(this, this.state);
            }
        }
    }
}
