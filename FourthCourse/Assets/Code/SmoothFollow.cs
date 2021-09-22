using UnityEngine;
using static UnityEngine.Screen;

namespace CodeGeek
{
    public class SmoothFollow : MonoBehaviour
    {
        public float Distance = 6.0f;
        public float Height = 2.0f;
        public float HeightDamping = 10.0f;
        //public float rotationDamping = 0.0f;
        public float Sensitivity = 10f;
        public Transform Target;
    
        private Vector3 _mousePos;
        private float _cameraRotation = 0f;
    
        private void LateUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                _mousePos = Input.mousePosition;
                _cameraRotation = ((_mousePos.x - (width / 2)) / width)*Sensitivity;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _cameraRotation = 0f;
            }
            
           if (!Target)
            {
                return;
            }
    
            float wantedRotationAngle = Target.eulerAngles.y;
            float wantedHeight = Target.position.y + Height;
    
            float currentHeight = transform.position.y;

            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, HeightDamping * Time.deltaTime);
    
           
            Quaternion currentRotation = Quaternion.Euler(0, _cameraRotation, 0);
    

            var pos = transform.position;
            pos = Target.position - currentRotation * Vector3.forward * Distance;
            pos.y = currentHeight;
            transform.position = pos;
    

            transform.LookAt(Target);
        }
    }
}
