using Code.MVC.Model;
using Code.MVC.View;
using GeekBrainsHW.MVC;
using UnityEngine;

namespace Code.MVC.Controller
{
    public class PlayerController : IMyUpdates
    {
        private PlayerModel _playerModel;
        private PlayerView _playerView;

        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

       
        public void OnUpdate()
        {

        }

        public void OnFixedUpdate()
        {
            _playerView.Move(_playerModel.Speed);
            _playerView.Jump(_playerModel.JumpForce);
        }
    }
}