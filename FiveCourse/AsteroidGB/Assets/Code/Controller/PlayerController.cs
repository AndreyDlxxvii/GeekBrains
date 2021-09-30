using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGB
{
    internal class PlayerController
    {
        private PlayerModel _playerModel { get; } 
        private PlayerView _playerView { get; }
        private RefResources _refResources;
        private IMovement _myMovement;
        //private IRotation _myRotation;
        private IFire _myFire;

        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
        }

        public void OnStart()
        {
            
            _refResources = new RefResources();
            _myMovement = new MyRotation(_playerView.GetComponent<Rigidbody>(), _playerModel.Speed, 
                                                _playerModel.Acceleration, _playerView.transform);
            _myFire = new MyFire(_playerView.GunPosition , 10f);
        }

        public void OnUpdate()
        {
            if (Input.GetButtonDown(AxisManager.Fire))
            {
                _myFire.Fire(_refResources.CoinPrefab);
            }

            if (Input.GetButtonDown(AxisManager.Acceleration))   
            {
                if (_myMovement is AccelerationSpeed accel)
                {
                    accel.IncreaseSpeed();
                }
            }

            if (Input.GetButtonUp(AxisManager.Acceleration))
            {
                if (_myMovement is AccelerationSpeed accel)
                {
                    accel.DecreaseSpeed();
                }
            }
        }
        public void OnFixedUpdate()
        {
            _myMovement.Movement(Input.GetAxis(AxisManager.Horizontal), Input.GetAxis(AxisManager.Vertical));
            if (_myMovement is MyRotation rotation) rotation.Rotation();
        }
    }
}


