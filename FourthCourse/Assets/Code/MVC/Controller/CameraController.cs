
namespace CodeGeek
{
    public class CameraController
    {
        private CameraView _cameraView;
        private CameraModel _cameraModel;

        public CameraController(CameraModel cameraModel, CameraView cameraView)
        {
            _cameraView = cameraView;
            _cameraModel = cameraModel;
        }


        public void OnLateUpdate()
        {
            _cameraView.FollowPlayer(_cameraModel.Offset, _cameraModel.PlayerTransform);
        }
    }
}