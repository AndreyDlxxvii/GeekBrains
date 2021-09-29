using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGB
{
    internal class GameController : MonoBehaviour
    {
        private PlayerController _controller;
        private RefResources _refResources;

        private void Awake()
        {
            _refResources = new RefResources();
            var player = _refResources.PlayerPrefab;
            _controller = new PlayerController(new PlayerModel(100f, 5f, 2f), FindObjectOfType<PlayerView>());
        }

        void Start()
        {
            _controller.OnStart();
        }

        void Update()
        {
            _controller.OnUpdate();
        }

        private void FixedUpdate()
        {
            _controller.OnFixedUpdate();
        }
    }
}


