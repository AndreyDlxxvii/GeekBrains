using UnityEngine;

namespace AsteroidGB
{
    internal class MyMovement : IMovement
    {
        private readonly Rigidbody _playerRigidbody;
        public float Speed { get; set;}


        private Vector2 _movement;

        public MyMovement(Rigidbody playerRigidbody, float speed)
        {
            _playerRigidbody = playerRigidbody;
            Speed = speed;
        }
        
        public void Movement(float HorizontalMovement, float VerticalMovement)
        {
            _movement.Set(HorizontalMovement, VerticalMovement);
            _playerRigidbody.AddForce(_movement * Speed);
        }
    }
}