using UnityEngine;

namespace AsteroidGB
{
    public class UFO : IEnemy
    {
        private GameObject _gameObject;
        public UFO(GameObject prefab)
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