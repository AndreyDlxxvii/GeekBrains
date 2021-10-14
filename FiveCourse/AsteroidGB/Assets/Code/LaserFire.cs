using UnityEngine;

namespace AsteroidGB
{
    internal class LaserFire : IFire
    {
        private LineRenderer _lineRenderer;
        private float _reloadTimeLaser;
        private TestCoroutine _coroutine;

        public LaserFire()
        {
            _coroutine = new TestCoroutine();
        }

        public void Fire(Transform gunTransform)
        {
            _coroutine.StartTestCoroutine(0.1f);
            Vector3 target = gunTransform.position + (gunTransform.rotation * Vector3.up) * 50f;
            _lineRenderer = gunTransform.GetComponent<LineRenderer>();
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, gunTransform.position);
            _lineRenderer.SetPosition(1, target);
            _coroutine.End += () =>
            {
                _lineRenderer.enabled = false;
                _coroutine.StopTestCoroutine();
                _coroutine.End -= () => { };
            };
        }
    }
}