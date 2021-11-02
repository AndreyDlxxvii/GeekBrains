using UnityEngine;

namespace AsteroidGB
{
    public class EnemyModel
    {
        public float _minSpeed { get; }
        public float _maxSpeed { get; }

        public EnemyModel(float minSpeed, float maxSpeed)
        {
            _minSpeed = minSpeed;
            _maxSpeed = maxSpeed;
        }
    }
}