using UnityEngine;

namespace AsteroidGB
{
    internal class MyRotation : AccelerationSpeed
    
    {
        private readonly Transform _transform;
        
        public MyRotation(Rigidbody playerRigidbody, float speed, float acceleration, Transform transform) 
            : base(playerRigidbody, speed, acceleration)
        {
            _transform = transform;
        }
     
        public void Rotation()
        {
            Vector3 rot = Camera.main.ScreenToWorldPoint(Input.mousePosition) - _transform.position;
            float rotate = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Euler(0f,0f,rotate);
        
        }



    }
}