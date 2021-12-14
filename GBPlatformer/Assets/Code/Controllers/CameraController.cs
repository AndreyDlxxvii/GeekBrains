using UnityEngine;

namespace GBPlatformer
{
    public class CameraController : IOnController, IOnLateUpdate
    {
        //TODO сделать офсет динамический
        
        private Transform _transformPlayer;
        private Transform _transformCamera;

        public CameraController(Transform transformPlayer, Transform transformCamera)
        {
            _transformPlayer = transformPlayer;
            _transformCamera = transformCamera;
        }

        public void OnLateUpdate(float deltaTime)
        {
            var designation = new Vector3(_transformPlayer.position.x, _transformPlayer.position.y, _transformCamera.position.z);
            _transformCamera.position = Vector3.Lerp(_transformCamera.position, designation, deltaTime);
        }
    }
}