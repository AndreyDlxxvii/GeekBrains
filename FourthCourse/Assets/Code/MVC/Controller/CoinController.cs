using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

namespace CodeGeek
{
    public class CoinController : IMyUpdates
    {
        //private CoinModel _coinModel;
        private CoinView _coinView;
        private GameObject [] _spawnGrounds;
        private GameObject _prefaCoin;

        private List<GameObject> _coinGameObjects;

        public CoinController(GameObject [] SpawnGrounds, GameObject PrefaCoin)
        {
            _prefaCoin = PrefaCoin;
            _coinView = _prefaCoin.GetComponent<CoinView>();
            _spawnGrounds = SpawnGrounds;
        }

        public void OnStart()
        {
            _coinGameObjects = new List<GameObject>(_spawnGrounds.Length);
            foreach (var ell in _spawnGrounds)
            {
                var position = ell.transform.TransformPoint(0f,0.5f,0f);
                var coin = Object.Instantiate(_prefaCoin, position, Quaternion.identity);
                coin.transform.SetParent(ell.transform);
                _coinGameObjects.Add(coin);
            }
        }

 
        public void OnUpdate()
        {
            foreach (var ell in _coinGameObjects)
            {
                if (ell != null)
                {
                    ell.GetComponent<CoinView>().FlayPingPong(1f);
                }
            }
        }

        public void OnFixedUpdate()
        {
        }
    }
}