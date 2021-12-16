using UnityEngine;

namespace MyRaces
{
    public class BtnCtrlController : BaseController
    {
        private readonly ResourcesPath _viewPath = new ResourcesPath{PathResoursec = "Prefabs/BtnControll"};
        private readonly Transform _placeUI;
        private readonly BtnControlView _btnControlView;

        public BtnCtrlController(Transform placeUI)
        {
            _placeUI = placeUI;
            _btnControlView = LoadView();
            _btnControlView.Move();
        }
        
        private BtnControlView LoadView()
        {
            var t = ResourceLoader.LoadPrefab(_viewPath);
            var objectView = Object.Instantiate(t, _placeUI, false);
            AddGameObject(objectView);
            if (objectView.TryGetComponent(out BtnControlView mainMenuView ))
            {
                return mainMenuView;
            }
            else return null;
        }
    }
}