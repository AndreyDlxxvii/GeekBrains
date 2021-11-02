using UnityEngine;
using UnityEngine.Rendering;

namespace AsteroidGB
{
    internal class BulletFire : IFire
    {
        private readonly float _forceBullet = 10f;
        private MyObjectPool _pool;
        private RefResources _refResources;
        private Rigidbody _rbBullet;

        public BulletFire(Rigidbody rbBullet)
        {
            _rbBullet = rbBullet;
            _pool = new MyObjectPool(_rbBullet);
        }

        public void Fire(Transform _gunTransform)
        {
            var _bullet = _pool.Create();
            _bullet.transform.position = _gunTransform.position;
            _bullet.transform.rotation = _gunTransform.rotation;
            _bullet.AddForce(_bullet.transform.up.normalized * _forceBullet, ForceMode.Impulse);
            
            var view = _bullet.GetComponent<BulletView>();
            view.Hit += () =>
            {
                _pool.Hide(_bullet);
                view.Hit -= () => { };
            };
        }
    }
}