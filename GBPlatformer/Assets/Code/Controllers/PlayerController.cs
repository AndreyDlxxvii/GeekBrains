using GBPlatformer.Model;
using UnityEngine;

namespace GBPlatformer
{
    public class PlayerController : IOnController, IOnUpdate
    {
        private LevelObjectView _playerView;
        private SpriteAnimController _spriteAnimController;
        private PlayerModel _playerModel;

        private float _xAxisInput;
        private bool _isJumping;
        
        private float _movingTreshold = 0.1f;
        
        private Vector3 _leftScale = new Vector3(-1,1,1);
        private Vector3 _rightScale = new Vector3(1,1,1);

        private bool _isMoving;
        
        private float _jumpTreshold = 1f;
        private const float _g = -9.8f;
        private float _groundLevel = -3f;
        private float _yVelocity;
        
        
        

        public PlayerController(LevelObjectView playerView, SpriteAnimController spriteAnimController, PlayerModel playerModel)
        {
            _playerView = playerView;
            _spriteAnimController = spriteAnimController;
            _playerModel = playerModel;
            _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Idle, true);
        }
        
        public void OnUpdate(float deltaTime)
        {
            _spriteAnimController.Update();
            CheckInput();
            Move(deltaTime);
            Jump(deltaTime);
        }

        private void CheckInput()
        {
            _xAxisInput = Input.GetAxis(AxisManager.Horizontal);
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            _isJumping = Input.GetAxis(AxisManager.Vertical) > 0f;
        }
        
        private void Move(float deltaTime)
        {
            if (_isMoving)
            {
                _xAxisInput = _xAxisInput > 0 ? 1 : -1;
                _playerView.Transform.position +=
                    Vector3.right * (deltaTime * _playerModel.Speed * _xAxisInput);
                _playerView.Transform.localScale = _xAxisInput < 0 ? _leftScale:_rightScale;
                _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Run, true);
            }
            else
            {
                _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Idle, true);
            }
        }
        
        private void Jump(float deltaTime)
        {
            if (_playerView.Transform.LowerThanYPos(_groundLevel) && _yVelocity <= 0f)
            {
                _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, _isMoving? AnimState.Run:AnimState.Idle, true);
                if (_isJumping)
                {
                    _yVelocity = _playerModel.JumpSpeed;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = float.Epsilon;
                    _playerView.Transform.position = _playerView.Transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                if (Mathf.Abs(_yVelocity)>_jumpTreshold)
                {
                    _spriteAnimController.StartAnimation(_playerView.SpriteRenderer, AnimState.Jump, true);
                }
                _yVelocity += _g * deltaTime;
                _playerView.Transform.position += Vector3.up * (deltaTime * _yVelocity);
            }
        }
    }
}