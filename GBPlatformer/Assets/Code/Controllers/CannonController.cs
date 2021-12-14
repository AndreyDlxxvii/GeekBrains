using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace GBPlatformer
{
    public class CannonController : IOnController, IOnUpdate
    {
        private Transform _transformTarget;
        private CannonView [] _cannonViews;
        private RefResources _refResources;
        private BulletPool _bulletPool;

        private Vector3 _dir;
        private Vector3 _axes;
        
        private Queue<Rigidbody2D> _bullets = new Queue<Rigidbody2D>();
        
        private float _angle;
        private float _delay;
        private float _timer;
        private float _range = 8f;
        
        public CannonController(Transform transformTarget, CannonView [] cannonViews, RefResources refResources)
        {
            _transformTarget = transformTarget;
            _cannonViews = cannonViews;
            _refResources = refResources;
            _bulletPool = new BulletPool(_refResources.Bullet);
        }

        //TODO сделать плавный поворот до цели
        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;
            if (_timer > 2f)
            {
                if (_bullets.Count > 0)
                {
                    _bulletPool.Hide(_bullets.Dequeue());
                }
                _timer = 0;
            }

            foreach (var ell in _cannonViews)
            {
                if (Vector3.Distance(ell.TransformMuzzle.position, _transformTarget.position) < _range)
                {
                    _dir = _transformTarget.position - ell.TransformMuzzle.position;
                    _angle = Vector3.Angle(Vector3.down, _dir);
                    _axes = Vector3.Cross(Vector3.down, _dir);
                    ell.TransformMuzzle.rotation = Quaternion.AngleAxis(_angle, _axes);
                    Fire(deltaTime, ell);
                }
            }
        }

        void Fire(float deltaTime, CannonView cannonView)
        {
            _delay += deltaTime;
            if (_delay > 1f)
            {
                var _bullet = _bulletPool.Create(cannonView.SpawnPoitMuzzle);
                _bullet.transform.rotation = cannonView.SpawnPoitMuzzle.rotation;
                _bullet.AddForce(-_bullet.transform.up * 10f, ForceMode2D.Impulse);
                _delay = 0f;
                _bullets.Enqueue(_bullet);
            }
        }
    }
}