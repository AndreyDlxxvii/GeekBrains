using UnityEngine;

namespace GBPlatformer
{
    public class CannonController : IOnController, IOnUpdate
    {
        private Transform _transformTarget;
        private CannonView _cannonView;
        private RefResources _refResources;

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axes;
        private BulletPool _bulletPool;
        private float _delay;
        private int test;
        private Rigidbody2D _bullet;

        public CannonController(Transform transformTarget, CannonView cannonView, RefResources refResources)
        {
            _transformTarget = transformTarget;
            //TODO сделать список пушок вместо одной
            _cannonView = cannonView;
            _refResources = refResources;
            _bulletPool = new BulletPool(_refResources.Bullet);
        }

        //TODO сделать плавный поворот до цели
        public void OnUpdate(float deltaTime)
        {
            if (Vector3.Distance( _cannonView.TransformMuzzle.position, _transformTarget.position) < 5f)
            {
                _dir = _transformTarget.position - _cannonView.TransformMuzzle.position;
                _angle = Vector3.Angle(Vector3.down, _dir);
                _axes = Vector3.Cross(Vector3.down, _dir);
                _cannonView.TransformMuzzle.rotation = Quaternion.AngleAxis(_angle, _axes);
            }

            if (_delay > 2f)
            {
                _bullet = _bulletPool.Create(_cannonView.SpawnPoitMuzzle);
                _bullet.transform.rotation = _cannonView.SpawnPoitMuzzle.rotation;
                _bullet.AddForce(-_bullet.transform.up * 10f, ForceMode2D.Impulse);
                _delay = 0f;
                test++;
                //TODO сделать условие уничтожения пуль
            }
            _delay += deltaTime;
        }
    }
}