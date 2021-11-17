using GBPlatformer.Model;
using UnityEngine;

namespace GBPlatformer
{
    public class GameInit
    {
        public GameInit(RefResources refResources, Controllers controllers)
        {
            var playerConfig = refResources.PlayerConfig;
            var playerView = new CreatePlayer(refResources.PlayerView);
            var playerAnimator = new SpriteAnimController(playerConfig);
            var playerModel = new PlayerModel(100f, 10f, 5f);
            var playerController = new PlayerController(playerView.PlayerMonoBeh(), playerAnimator, playerModel);

           controllers.Add(playerController);
        }
    }
}