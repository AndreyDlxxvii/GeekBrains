using UnityEngine;

namespace AsteroidGB
{
    public class UFOController : IController, IOnStart, IOnFixedUpdate
    {
        private UFOModel _ufoModel;
        private EnemyView _enemyView;

        private GameObject _player;
        private Rigidbody _rb;

        private Vector3[] _direction;
        private Vector3 _randomVectorDirection;

        public UFOController(UFOModel ufoModel, EnemyView enemyView)
        {
            _ufoModel = ufoModel;
            _enemyView = enemyView;
        }


        public void OnStart()
        {
            _player = GameObject.FindWithTag("Player");
            _rb = _enemyView.GetComponent<Rigidbody>();
            _direction = new[] {Vector3.down, Vector3.left, Vector3.right, Vector3.up};
            var i = _direction[Random.Range(0, _direction.Length)];
            _randomVectorDirection = _enemyView.transform.position - _direction[Random.Range(0, _direction.Length)];
        }

        public void OnFixedUpdate()
        {
            if (_enemyView != null)
            {
                MoveUfo();
            }
        }

        private void MoveUfo()
        {
            if (_player != null && Vector3.Distance(_enemyView.transform.position, _player.transform.position) < 5f)
            {
                _rb.AddForce((_player.transform.position - _enemyView.transform.position).normalized * 2f);
            }
            else
            {
                _rb.AddForce(_randomVectorDirection.normalized * 1.5f);
            }
        }
    }
}
