using System;
using UnityEngine;

namespace GeekBrainsHW.MVC
{
    public class MyStarter : MonoBehaviour
    {
        private PlayerController _playerController;
        private PlayerModel _playerModel;
        private PlayerView _playerView;

        private void Start()
        {
            _playerController = new PlayerController(new PlayerModel(5f,100f), FindObjectOfType<PlayerView>());
        }

        private void Update()
        {
            
        }

        private void FixedUpdate()
        {
            _playerController.OnFixedUpdate();
        }
    }
}