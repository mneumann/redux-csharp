namespace Redux.Csharp
{
    public interface IReducer<STATE, ACTION>
        where STATE : IState
        where ACTION : IReduxAction
    {
        STATE Reduce(STATE oldState, ACTION action);
    }
}
