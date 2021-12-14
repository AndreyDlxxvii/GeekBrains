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
            return Object.Instantiate(_playerPref, Vector3.zero, Quaternion.identity).GetComponent<LevelObjectView>();
        }
    }
}