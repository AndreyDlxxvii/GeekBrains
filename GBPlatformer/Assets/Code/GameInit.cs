using GBPlatformer.Model;
using UnityEngine;

namespace GBPlatformer
{
    public class GameInit
    {
        public GameInit(RefResources refResources, Controllers controllers)
        {
            var playerModel = new PlayerModel(100f, 100f, 10f);
            var playerConfig = refResources.PlayerConfig;
            var managerObjects = new ManagerObjects(refResources);
            var playerMonoBeh = managerObjects.PlayerCreateMonoBeh();
            var cannonMonoBeh = Object.FindObjectOfType<CannonView>();
            var playerAnimator = new SpriteAnimController(playerConfig);
            
            
            var playerController = new PlayerController(playerMonoBeh, playerAnimator, playerModel);
            var cameraController = new CameraController(playerMonoBeh.Transform, Camera.main?.transform);
            var cannonController = new CannonController(playerMonoBeh.Transform, cannonMonoBeh, refResources);

           controllers.Add(playerController);
           controllers.Add(cameraController);
           controllers.Add(cannonController);
        }
    }
}