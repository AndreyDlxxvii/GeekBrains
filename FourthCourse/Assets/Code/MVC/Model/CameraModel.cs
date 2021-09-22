using UnityEngine;

namespace CodeGeek
{
    public readonly struct CameraModel
    {
        public float Offset { get; }
        public Transform PlayerTransform { get; }

        public CameraModel(float offset, Transform playerTransform)
        {
            Offset = offset;
            PlayerTransform = playerTransform;
        }
    }
}