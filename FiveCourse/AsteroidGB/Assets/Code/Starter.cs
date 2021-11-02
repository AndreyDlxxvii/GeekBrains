using System;
using UnityEngine;

namespace AsteroidGB
{
    public class Starter : MonoBehaviour
    {
        RefResources _resources = new RefResources();
        Controllers _controllers;

        // private void Awake()
        // {
        //     
        // }

        private void Start()
        {
            _controllers = new Controllers();
            new GameInit(_resources, _controllers);
            _controllers.OnStart();
        }

        private void Update()
        {
            _controllers.OnUpdate();
        }

        private void FixedUpdate()
        {
            _controllers.OnFixedUpdate();
        }
    }
}