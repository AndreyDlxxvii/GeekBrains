using UnityEngine;

namespace GBPlatformer
{
    public class ManagerObjects
    {
        private LevelObjectView _playerPref;
        public ManagerObjects(RefResources resources)
        {
            _playerPref = resources.PlayerView;
        }
        public LevelObjectView PlayerCreateMonoBeh()
        {
            var start = new Vector3(-5f, -3.5f, 0f);
            return Object.Instantiate(_playerPref, start, Quaternion.identity).GetComponent<LevelObjectView>();
        }
    }
}