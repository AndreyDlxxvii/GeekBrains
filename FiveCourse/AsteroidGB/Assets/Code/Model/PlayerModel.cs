using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGB
{
    internal class PlayerModel
    {
        public float Live { get; }
        public float Speed { get; }
        public float Acceleration { get; }

        public PlayerModel(float live, float speed, float acceleration)
        {
            
            Acceleration = acceleration;
            Live = live;
            Speed = speed;
        }
    }
}



