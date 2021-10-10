using UnityEngine;


namespace AsteroidGB
{
    public class RefResources
    {
        private GameObject _bulletPrefab;
        private GameObject _player;
        private GameObject _asteroid;
        private GameObject _asteroidBig;
        private GameObject _asteroidMedium;
        private GameObject _ufo;
        private Sprite _spriteAsteroid;
        private Sprite _spriteBullet;
        
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
        
        public GameObject AsteroidPrefabMedium
        {
            get 
            {
                if (_asteroidMedium == null)
                {
                    _asteroidMedium = Resources.Load<GameObject>("AsteroidMedium");
                }
                return _asteroidMedium;
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

        public Sprite AsteroidSprite
        {
            get 
            {
                if (_spriteAsteroid == null)
                {
                    _spriteAsteroid = Resources.Load<Sprite>("Sprites/Asteroid");
                }
                return _spriteAsteroid;    
            }
        }
        
        public Sprite BulletSprite
        {
            get 
            {
                if (_spriteBullet == null)
                {
                    _spriteBullet = Resources.Load<Sprite>("Sprites/BulletSprite");
                }
                return _spriteBullet;    
            }
        }
    }
}