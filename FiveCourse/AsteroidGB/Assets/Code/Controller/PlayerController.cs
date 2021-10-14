using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGB
{
    public class PlayerController: IOnFixedUpdate, IController, IOnUpdate
    {
        private PlayerModel _playerModel { get; } 
        private PlayerView _playerView { get; }
        
        private RefResources _refResources;
        private IMovement _myMovement;
        private WeaponController _weaponController;

        private WeaponProxy _weaponProxy;
        private UnlockWeapon _unlockWeapon;


        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            _playerModel = playerModel;
            _playerView = playerView;
            _refResources = new RefResources();
            _weaponController = new WeaponController(_refResources);
            
            // Залочка оружия
            // _unlockWeapon = new UnlockWeapon(true);
            // _weaponProxy = new WeaponProxy(new LaserFire(), _unlockWeapon);
            
            _myMovement = new MyRotation(_playerView.GetComponent<Rigidbody>(), _playerModel.Speed, 
                _playerModel.Acceleration, _playerView.transform);
        }

        public void OnUpdate()
        {
            if (Input.GetButtonDown(AxisManager.Fire))
            {
                //_weaponProxy.Fire(_playerView.GunPosition);
                _weaponController.Atack(_playerView.GunPosition);
            }

            if (Input.GetButtonDown(AxisManager.ChangeWeapon))
            {
                _weaponController.ChangeWeapon();
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


