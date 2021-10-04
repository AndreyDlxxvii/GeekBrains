using UnityEngine;

namespace AsteroidGB
{
    internal class AsteroidEnemyBig : IEnemy
    {
        private GameObject _gameObject;
        public AsteroidEnemyBig(GameObject prefab)
        {
            _gameObject = prefab;
        }

        //TODO сделать рандомный спавн
        public EnemyView Create()
        {
            return Object.Instantiate(_gameObject, Vector3.right, Quaternion.identity).GetComponent<EnemyView>();
        }
    }
}