using Code.MVC.View;
using UnityEngine;

namespace Code.MVC.Controller
{
    public class SaveController
    {
        private PlayerView _playerView;
        private GameManager _gameManager;
        private SaveGameData _saveGameData;
        private const KeyCode SaveGame = KeyCode.C;
        private const KeyCode LoadGame = KeyCode.V;

        public SaveController(PlayerView playerView, GameManager gameManager)
        {
            _playerView = playerView;
            _gameManager = gameManager;
            _saveGameData = new SaveGameData();
        }
        
        public void OnUpdate()
        {
            if (Input.GetKeyDown(SaveGame))
            {
                _saveGameData.SaveGame(_playerView, _gameManager);
            }

            if (Input.GetKeyDown(LoadGame))
            {
                _saveGameData.LoadGame(_playerView, _gameManager);
            }
        }
    }
}