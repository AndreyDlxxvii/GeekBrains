using UnityEngine;

namespace GBPlatformer
{
    public class RefResources
    {
        private SpriteAnimConfig _playerConfig;
        private SpriteAnimConfig _coiAnimConfigConfig;
        private LevelObjectView _playerView;
        private Rigidbody2D _bulletView;
        private CannonView _cannonView;

        public SpriteAnimConfig PlayerConfig
        {
            get
            {
                if (_playerConfig == null)
                {
                    _playerConfig = Resources.Load<SpriteAnimConfig>(PrefabNameManager.PlayerAnimCFG);
                }
                return _playerConfig;
            }
        }
        
        public SpriteAnimConfig CoiAnimConfigConfig
        {
            get
            {
                if (_coiAnimConfigConfig == null)
                {
                    _coiAnimConfigConfig = Resources.Load<SpriteAnimConfig>(PrefabNameManager.CoinAnim);
                }
                return _coiAnimConfigConfig;
            }
        }

        public LevelObjectView PlayerView
        {
            get
            {
                if (_playerView == null)
                {
                    _playerView = Resources.Load<LevelObjectView>(PrefabNameManager.Player);
                }

                return _playerView;
            }
        }
        
        public CannonView CannonView
        {
            get
            {
                if (_cannonView == null)
                {
                    _cannonView = Resources.Load<CannonView>(PrefabNameManager.Gun);
                }

                return _cannonView;
            }
        }
        
        public Rigidbody2D Bullet
        {
            get
            {
                if (_bulletView == null)
                {
                    _bulletView = Resources.Load<Rigidbody2D>(PrefabNameManager.Bullet);
                }

                return _bulletView;
            }
        }
    }
}