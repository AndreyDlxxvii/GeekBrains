using UnityEngine;

namespace AsteroidGB
{
    public class PlayerMove : State
    {
        private float _moveHorizontal;
        private float _moveVertical;
        private bool _stopMovement;
        public PlayerMove(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
            
        }
        
        public override void Enter()
        {
            _stopMovement = false;
            _moveHorizontal = _moveVertical = 0.0f;
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            _moveHorizontal = Input.GetAxis("Horizontal");
            _moveVertical = Input.GetAxis("Vertical");
            _stopMovement = Input.GetButtonDown("Jump");
            Debug.Log(_stopMovement);
        }

        public override void OnFixedUpdate()
        {
            _player.Movement(_moveHorizontal, _moveVertical);
            if (_stopMovement)
            {
                Debug.Log(_stopMovement);
                _stateMachine.ChangeState(_player.PlayerStay);
            }
        }
        
        public override void Exit()
        {
            _player.StopMovement();
        }
    }
}