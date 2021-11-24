using System.Collections.Generic;
using System.Linq;
using GBPlatformer.Model;
using UnityEngine;

namespace GBPlatformer
{
    public class GameInit
    {
        public GameInit(RefResources refResources, Controllers controllers)
        {
            var playerModel = new PlayerModel(100f, 100f, 7f);
            var playerConfig = refResources.PlayerConfig;
            var coinConfig = refResources.CoiAnimConfigConfig;
            var managerObjects = new ManagerObjects(refResources);
            var playerMonoBeh = managerObjects.PlayerCreateMonoBeh();
            var cannonViews = Object.FindObjectsOfType<CannonView>();
            var coinViews = Object.FindObjectsOfType<CoinObjectView>().ToList();
            var playerAnimator = new SpriteAnimController(playerConfig);
            var coinAnimator = new SpriteAnimController(coinConfig);
            
            
            var playerController = new PlayerController(playerMonoBeh, playerAnimator, playerModel);
            var cameraController = new CameraController(playerMonoBeh.Transform, Camera.main?.transform);
            var cannonController = new CannonController(playerMonoBeh.Transform, cannonViews, refResources);
            var coinController = new CoinController(coinAnimator, coinViews, playerMonoBeh);

           controllers.Add(playerController);
           controllers.Add(cameraController);
           controllers.Add(cannonController);
           controllers.Add(coinController);
        }
    }
}