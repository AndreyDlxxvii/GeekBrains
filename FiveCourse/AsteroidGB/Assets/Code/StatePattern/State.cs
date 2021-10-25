namespace AsteroidGB
{
    public abstract class State
    {
        protected Player _player;
        protected StateMachine _stateMachine;

        protected State(Player player, StateMachine stateMachine)
        {
            _player = player;
            _stateMachine = stateMachine;
        }
        
        public virtual void Enter()
        {
            
        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnFixedUpdate()
        {

        }

        public virtual void Exit()
        {

        }
    }
}