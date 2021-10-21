using UnityEngine;

namespace AsteroidGB
{
    internal class AccelerationSpeed : MyMovement
    {
        private float _acceleration;
        
        public AccelerationSpeed(Rigidbody playerRigidbody, float speed, float acceleration) : base(playerRigidbody, speed)
        {
            _acceleration = acceleration;
        }

        public void IncreaseSpeed()
        {
            Speed += _acceleration;
        }

        public void DecreaseSpeed()
        {
            Speed -= _acceleration;
        }
    }
}