using System;
using System.IO;
using UnityEngine;

namespace CodeGeek
{
    [Serializable]
    public sealed class SaveGameData
    {
        private readonly JsonData _dataInfo;
        
        private const string _folderName = "Saves";
        private const string _fileName = "data.bat";
        private readonly string _path;
        public SaveGameData()
        {
            _dataInfo = new JsonData();
            _path = Path.Combine(Application.dataPath, _fileName);
        }

        public void SaveGame(PlayerView playerView, GameManager gameManager)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var data = new DataInfo {Position = playerView.transform.position, Score = gameManager.Score};
            _dataInfo.Save(data,Path.Combine(_path, _folderName));   
        } 
        
        public void LoadGame(PlayerView playerView, GameManager gameManager)
        {
            var saveFiles = Path.Combine(_path, _folderName);
            var newPlayer = _dataInfo.Load(saveFiles);
            playerView.transform.position = newPlayer.Position;
            gameManager.Score = newPlayer.Score;
        }

    }
}