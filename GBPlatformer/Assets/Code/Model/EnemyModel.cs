using UnityEngine;

namespace GBPlatformer.Model
{
    public class EnemyModel
    {
        public Transform Target { get; }
        public float Speed { get; }

        public EnemyModel(Transform target, float speed)
        {
            Target = target;
            Speed = speed;
        }
    }
}