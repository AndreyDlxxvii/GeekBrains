using UnityEngine;

namespace AsteroidGB
{
    internal class MyFire : IFire
    {
        private readonly Transform _gunTransform;
        private readonly float _forceBullet;
        //private MyObjectPool _pool;
        private RefResources _refResources;
        private TestCoroutine _coroutine;

        public MyFire(Transform gunTransform, float forceBullet, RefResources refResources)
        {
            _coroutine = new TestCoroutine();
            _gunTransform = gunTransform;
            _forceBullet = forceBullet;
            _refResources = refResources;
            //доступ к пулу объектов через сервислокатор
            MyServiceLocator.SetLocator(new MyObjectPool(refResources.BulletPrefab));
            //_pool = new MyObjectPool(refResources.BulletPrefab);
            //создание пули через строителя (расширение)
            // _pool = new MyObjectPool(new GameObject().AddRigidbody().AddSprite(_refResources.BulletSprite).SetName("Bullet")
            //     .AddBoxCollider().AddScriptView<BulletView>().AddTag("Bullet"));
            _coroutine = new TestCoroutine();
        }

        public void Fire()
        {
            //var bullet = _pool.Create();
            var bullet = MyServiceLocator.GetLocator<MyObjectPool>().Create();
            bullet.transform.position = _gunTransform.position;
            bullet.transform.rotation = _gunTransform.rotation;
            var rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.up.normalized * _forceBullet, ForceMode.Impulse);
            
            var view = bullet.GetComponent<BulletView>();
            view.Hit += () =>
            {
                MyServiceLocator.GetLocator<MyObjectPool>().Hide(bullet);
                //_pool.Hide(bullet);
                view.Hit -= () => { };
            };


        }
    }
}