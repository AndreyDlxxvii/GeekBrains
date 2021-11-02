using UnityEngine;

namespace AsteroidGB
{
    public class PlayerStay : State
    {
        private bool _moveHorizontal;
        private bool _moveVertical;
        
        public PlayerStay(Player player, StateMachine stateMachine) : base(player, stateMachine)
        {
            
        }

        public override void Enter()
        {
            _moveHorizontal = false;
            _moveVertical = false;
            _player.transform.position = Vector3.zero;
        }

        public override void OnUpdate()
        {
            _moveHorizontal = Input.GetButtonDown("Horizontal");
            _moveVertical = Input.GetButtonDown("Vertical");
            if (_moveHorizontal | _moveVertical)
            {
                _stateMachine.ChangeState(_player.PlayerMove);
            }
        }
    }
}