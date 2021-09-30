using UnityEngine;


namespace AsteroidGB
{
    public class RefResources
    {
        private GameObject _bulletPrefab;
        private GameObject _player;
        
        public GameObject CoinPrefab
        {
            get 
            {
                if (_bulletPrefab == null)
                {
                    _bulletPrefab = Resources.Load<GameObject>("Bullet");
                }
                return _bulletPrefab;
            }
        }
        
        public GameObject PlayerPrefab
        {
            get 
            {
                if (_player == null)
                {
                    _player = Object.Instantiate(Resources.Load<GameObject>("Player"), Vector3.zero, Quaternion.identity)
                        ;
                }
                return _player;
            }
        }
        
    }
}