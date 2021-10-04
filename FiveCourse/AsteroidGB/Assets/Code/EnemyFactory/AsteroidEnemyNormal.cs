using Unity.Mathematics;
using UnityEngine;

namespace AsteroidGB
{
    internal class AsteroidEnemyNormal : IEnemy
    {
        private GameObject _gameObject;
        public AsteroidEnemyNormal(GameObject prefab)
        {
            _gameObject = prefab;
        }
        //TODO сделать рандомный спавн
        public EnemyView Create()
        {
            return Object.Instantiate(_gameObject, Vector3.right, quaternion.identity).GetComponent<EnemyView>();
        }

    }
}