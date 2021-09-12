using System;
using System.Collections.Generic;
using CCodeGeek;
using UnityEngine;
using static UnityEngine.Random;

namespace CodeGeek
{
    public class MyStarter : MonoBehaviour
    {
        
        private const string Ground = "Ground";
        private PlayerController _playerController;
        private CameraController _cameraController;
        private CoinController _coinControllers;
        private SaveController _saveController;
        private RefResources _ref;
        private GameManager _gameManager;
       
        private void Awake()
        {
            _ref = new RefResources();
            InitControllers();
            _gameManager.OnAwake();
        }

        private void Start()
        {
            _gameManager.OnStart();
            _coinControllers.OnStart();
            //MakeCoinOnTargets();
        }

        private void InitControllers()
        {
            _gameManager = new GameManager();
            _saveController = new SaveController(FindObjectOfType<PlayerView>(), _gameManager);
            _playerController = new PlayerController(new PlayerModel(5f, 100f),FindObjectOfType<PlayerView>());
            _cameraController = new CameraController(new CameraModel(9f, FindObjectOfType<PlayerView>().transform),FindObjectOfType<CameraView>());
            _coinControllers = new CoinController(GameObject.FindGameObjectsWithTag(Ground), _ref.CoinPrefab);
        }
        
        // private void MakeCoinOnTargets()
        // {
        //     var objects = GameObject.FindGameObjectsWithTag(Ground);
        //     _coinControllers = new List<CoinController>(objects.Length);
        //     foreach (var obj in objects)
        //     {
        //         var position = obj.transform.TransformPoint(0f,0.5f,0f);
        //         var coin = Instantiate(_ref.CoinPrefab, position, Quaternion.identity);
        //         coin.transform.SetParent(obj.transform);
        //         var i = Range(0.5f, 1f);
        //         var q = new CoinController(new CoinModel(i), coin.GetComponent<CoinView>());
        //         _coinControllers.Add(q);
        //     }
        // }

        private void Update()
        {
            _saveController.OnUpdate();
            _coinControllers.OnUpdate();
            // foreach (var obj in _coinControllers)
            // {
            //     obj.OnUpdate();
            // }
        }

        private void FixedUpdate()
        {
            _playerController.OnFixedUpdate();
        }

        private void LateUpdate()
        {
            _cameraController.OnLateUpdate();
        }
    }
}