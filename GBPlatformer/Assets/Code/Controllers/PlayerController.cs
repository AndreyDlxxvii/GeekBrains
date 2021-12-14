using GBPlatformer.Model;
using UnityEngine;

namespace GBPlatformer
{
    public class PlayerController : IOnController, IOnUpdate, IOnFixedUpdate
    {
        private LevelObjectView _playerView;
        private SpriteAnimController _spriteAnimController;
        private PlayerModel _playerModel;
        private ContactPooler _contactPooler;

        private float _xAxisInput;
        private bool _isJumping;
        
        private float _movingTreshold = 0.1f;
        
        private Vector3 _leftScale = new Vector3(-1,1,1);
        private Vector3 _rightScale = new Vector3(1,1,1);

        private bool _isMoving;
        
        private float _jumpTreshold = 1f;
        private float _groundLevel = -3f;
        private float _yVelocity;
        private float _xVelocity;
        
        public PlayerController(LevelObjectView playerView, SpriteAnimController spriteAnimController, PlayerModel playerModel)
        {
            _playerView = playerView;
            _spriteAnimController = spriteAnimController;
            _playerModel = playerModel;
            _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Idle, true);
            _contactPooler = new ContactPooler(_playerView.Collider2D);
        }
        
        public void OnUpdate(float deltaTime)
        {
            _contactPooler.Update();
            _spriteAnimController.Update();
            CheckInput();
            
        }
        
        public void OnFixedUpdate(float fixedDeltaTime)
        {
            Move(fixedDeltaTime);
            Jump(fixedDeltaTime);
        }

        private void CheckInput()
        {
            _xAxisInput = Input.GetAxis(AxisManager.Horizontal);
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            _isJumping = Input.GetAxis(AxisManager.Vertical) > 0f;
        }
        
        private void Move(float fixedDeltaTime)
        {
            if (_isMoving)
            {
                _xAxisInput = _xAxisInput > 0 ? 1 : -1;
                _xVelocity = fixedDeltaTime * _playerModel.Speed * _xAxisInput;
                _playerView.Rigidbody2D.velocity = _playerView.Rigidbody2D.velocity.Change(x: _xVelocity);
                _playerView.Transform.localScale = _xAxisInput < 0 ? _leftScale:_rightScale;
                _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Run, true);
            }
            else
            {
                _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Idle, true);
            }
        }
        
        private void Jump(float fixedDeltaTime)
        {
            if (_contactPooler.IsGrounded)
            {
                _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, _isMoving? AnimState.Run:AnimState.Idle, true);
                if (_isJumping && Mathf.Abs(_playerView.Rigidbody2D.velocity.y)<= _jumpTreshold)
                {
                    _playerView.Rigidbody2D.AddForce(Vector2.up*_playerModel.JumpSpeed, ForceMode2D.Impulse);
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = float.Epsilon;
                    _playerView.Transform.position = _playerView.Transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (Mathf.Abs(_playerView.Rigidbody2D.velocity.y)>= _jumpTreshold)
                {
                    _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Jump, true);
                }
            }
        }


    }
}