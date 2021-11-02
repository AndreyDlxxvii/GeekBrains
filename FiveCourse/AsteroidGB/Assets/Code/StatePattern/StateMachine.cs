namespace AsteroidGB
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }
        
        public void Init (State startState)
        {
            CurrentState = startState;
            startState.Enter();
        }

        public void ChangeState(State newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}