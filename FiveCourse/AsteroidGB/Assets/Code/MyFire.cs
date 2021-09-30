using UnityEngine;

namespace AsteroidGB
{
    internal class MyFire : IFire
    {
        private readonly Transform _gunTransform;
        private readonly float _forceBullet;

        public MyFire(Transform gunTransform, float forceBullet)
        {
            _gunTransform = gunTransform;
            _forceBullet = forceBullet;
        }

        public void Fire(GameObject _prefabGameObject)
        {
            var bullet = Object.Instantiate(_prefabGameObject, _gunTransform.position, _gunTransform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.up * _forceBullet, ForceMode.Impulse
            );
            
        }
    }
}