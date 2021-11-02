using System;
using UnityEngine;

namespace AsteroidGB
{
    public class Starter : MonoBehaviour
    {
        RefResources _resources = new RefResources();
        MyControllers _myControllers;

        // private void Awake()
        // {
        //     
        // }

        private void Start()
        {
            _myControllers = new MyControllers();
            new GameInit(_resources, _myControllers);
            _myControllers.OnStart();
        }

        private void Update()
        {
            _myControllers.OnUpdate();
        }

        private void FixedUpdate()
        {
            _myControllers.OnFixedUpdate();
        }
    }
}