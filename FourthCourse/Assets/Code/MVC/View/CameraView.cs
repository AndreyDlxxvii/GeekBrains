using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Code.MVC.View
{
    public class CameraView : MonoBehaviour
    {
        
        public void FollowPlayer(float offset, Transform playerTransform)
        {
            FindObjectOfType<CameraView>().transform.position = playerTransform.position + Vector3.up*offset;
        }
    }
}