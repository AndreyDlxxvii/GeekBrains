using CodeGeek;
using UnityEngine;

namespace AsteroidGB
{
    internal class MyFire : IFire
    {
        private readonly Transform _gunTransform;
        private readonly float _forceBullet;
        private MyObjectPool _pool;
        private TestCoroutine _coroutine;

        public MyFire(Transform gunTransform, float forceBullet, GameObject _prefabGameObject)
        {
            _coroutine = new TestCoroutine();
            _gunTransform = gunTransform;
            _forceBullet = forceBullet;
            _pool = new MyObjectPool(_prefabGameObject);
            _coroutine = new TestCoroutine();
        }

        public void Fire()
        {
            var bullet = _pool.Create();
            bullet.transform.position = _gunTransform.position;
            bullet.transform.rotation = _gunTransform.rotation;
            var rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.up.normalized * _forceBullet, ForceMode.Impulse);
            
            var view = bullet.GetComponent<BulletView>();
            view.Hit += () =>
            {
                _pool.Hide(bullet);
                view.Hit -= () => { };
            };


        }
    }
}