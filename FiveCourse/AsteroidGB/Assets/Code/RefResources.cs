using UnityEngine;


namespace AsteroidGB
{
    public class RefResources
    {
        private GameObject _bulletPrefab;
        private GameObject _player;
        private GameObject _asteroid;
        private GameObject _asteroidBig;
        private GameObject _ufo;
        
        public GameObject BulletPrefab
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
                    _player = Resources.Load<GameObject>("Player");
                }
                return _player;
            }
        }
        
        public GameObject AsteroidPrefab
        {
            get 
            {
                if (_asteroid == null)
                {
                    _asteroid = Resources.Load<GameObject>("Asteroid");
                }
                return _asteroid;
            }
        }
        public GameObject AsteroidPrefabBig
        {
            get 
            {
                if (_asteroidBig == null)
                {
                    _asteroidBig = Resources.Load<GameObject>("AsteroidBig");
                }
                return _asteroidBig;
            }
        }
        
        public GameObject UFO
        {
            get 
            {
                if (_ufo == null)
                {
                    _ufo = Resources.Load<GameObject>("UFO");
                }
                return _ufo;
            }
        }
        
    }
}