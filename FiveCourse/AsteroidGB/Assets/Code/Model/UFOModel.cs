using System;

namespace AsteroidGB
{
    [Serializable]
    public class UFOModel
    {
        public float Speed { get; }
        public float HP { get; }

        public UFOModel(float speed, float hp)
        {
            Speed = speed;
            HP = hp;
        }
    }
}