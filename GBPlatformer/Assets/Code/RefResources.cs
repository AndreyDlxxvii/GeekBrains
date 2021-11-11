using UnityEngine;

namespace GBPlatformer
{
    public class RefResources
    {
        private SpriteAnimConfig _playerConfig;
        private LevelObjectView _playerView;

        public SpriteAnimConfig PlayerConfig
        {
            get
            {
                if (_playerConfig == null)
                {
                    _playerConfig = Resources.Load<SpriteAnimConfig>("PlayerAnimCFG");
                }
                return _playerConfig;
            }
        }

        public LevelObjectView PlayerView
        {
            get
            {
                if (_playerView == null)
                {
                    _playerView = Resources.Load<LevelObjectView>("Player");
                }

                return _playerView;
            }
        }
    }
}