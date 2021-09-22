using System.Collections.Generic;
using Code.MVC.Controller;
using Code.MVC.Model;
using Code.MVC.View;
using GeekBrainsHW.MVC;
using UnityEngine;
using static UnityEngine.Random;

namespace Code.MVC
{
    public class MyStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _prefabCoin;
        
        private const string Ground = "Ground";
        private PlayerController _playerController;
        private CoinController _coinController;
        private PlayerModel _playerModel;
        private PlayerView _playerView;
        private CoinModel _coinModel;
        private CoinView _coinView;
        private bool _gameOver = false;
        private List<CoinController> _coinControllers;

        private void Awake()
        {
            var a = new HW7.HW7();
            a.Task2();
            a.Task3();
            a.Task4();
            _coinView = _prefabCoin.GetComponent<CoinView>();
        }

        private void Start()
        {
            MakePlayer();
            MakeCoinOnTargets();
        }

        private void MakePlayer()
        {
            _playerController = new PlayerController(new PlayerModel(5f, 100f), FindObjectOfType<PlayerView>());
            _playerView = FindObjectOfType<PlayerView>();
        }

        private void MakeCoinOnTargets()
        {
            
            var objects = GameObject.FindGameObjectsWithTag(Ground);
            _coinControllers = new List<CoinController>(objects.Length);
            foreach (var obj in objects)
            {
                var position = obj.transform.TransformPoint(0f,0.5f,0f);
                var coin = Instantiate(_prefabCoin, position, Quaternion.identity);
                coin.transform.SetParent(obj.transform);
                var i = Range(0.5f, 1f);
                var q = new CoinController(new CoinModel(i), coin.GetComponent<CoinView>());
                _coinControllers.Add(q);
            }
        }

        private void Update()
        {
            foreach (var obj in _coinControllers)
            {
                obj.OnUpdate();
            }
        }
        
        private void FixedUpdate()
        {
            _playerController.OnFixedUpdate();
        }
    }
}