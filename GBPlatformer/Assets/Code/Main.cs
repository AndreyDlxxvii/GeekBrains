using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{
    public class Main : MonoBehaviour
    {
        private RefResources _refResources = new RefResources();
        private Controllers _controllers;
        private SpriteAnimController _playerAnimator;

        void Start()
        {
            _controllers = new Controllers();
            new GameInit(_refResources, _controllers);
            _controllers.OnStart();
        }

        void Update()
        {
            _controllers.OnUpdate();
        }
    }
}
