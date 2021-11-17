using UnityEngine;

namespace GBPlatformer
{
    public class GameInit
    {
        public GameInit(RefResources refResources, Controllers controllers)
        {
            var _playerConfig = refResources.PlayerConfig;
            var _playerView = new CreatePlayer(refResources.PlayerView);
            var _playerAnimator = new SpriteAnimController(_playerConfig, _playerView.PlayerMonoBeh());

            controllers.Add(_playerAnimator);
        }
    }
}