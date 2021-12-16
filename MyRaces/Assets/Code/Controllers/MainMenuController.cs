using UnityEngine;

namespace MyRaces
{
    public class MainMenuController : BaseController
    {
        private readonly ResourcesPath _viewPath = new ResourcesPath{PathResoursec = "Prefabs/mainMenu"};
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _mainMenuView;
        private readonly Transform _placeUI;

        public MainMenuController(Transform placeUI,  ProfilePlayer profilePlayer)
        {
            _placeUI = placeUI;
            _profilePlayer = profilePlayer;
            _mainMenuView = LoadView();
            _mainMenuView.Init(StartGame);
        }


        private MainMenuView LoadView()
        {
            var t = ResourceLoader.LoadPrefab(_viewPath);
            var objectView = Object.Instantiate(t, _placeUI, false);
            AddGameObject(objectView);
            if (objectView.TryGetComponent(out MainMenuView mainMenuView ))
            {
                return mainMenuView;
            }
            else return null;
        }
        private void StartGame()
        {
            _profilePlayer.CurrentState.value = GameState.Start;
        }
    }
}