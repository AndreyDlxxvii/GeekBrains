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
            //var playerMonoBeh = Object.FindObjectOfType<LevelObjectView>();
            var cannonViews = Object.FindObjectsOfType<CannonView>();
            var enemyView = Object.FindObjectOfType<EnemyObjectView>();
            var coinViews = Object.FindObjectsOfType<LevelObjectView>().ToList();
            var playerAnimator = new SpriteAnimController(playerConfig);
            var coinAnimator = new SpriteAnimController(coinConfig);
            var generatorLevelView = Object.FindObjectOfType<GeneratorLevelView>();
            var questView = Object.FindObjectOfType<QuestView>();
            var doorView = Object.FindObjectOfType<DoorView>();
            
            
            
            var playerController = new PlayerController(playerMonoBeh, playerAnimator, playerModel);
            var cameraController = new CameraController(playerMonoBeh.Transform, Camera.main?.transform);
            var cannonController = new CannonController(playerMonoBeh.Transform, cannonViews, refResources);
            var coinController = new CoinController(coinAnimator, coinViews, playerMonoBeh);
            var enemyController = new EnemysController(enemyView,playerMonoBeh);
            var genCtrl = new GeneratorController(generatorLevelView);
            var doorController = new DoorController(doorView);
            var questCfgController = new QuestCofiguratorController(questView, doorController);
            

           controllers.Add(playerController);
           controllers.Add(cameraController);
           controllers.Add(cannonController);
           controllers.Add(coinController);
           controllers.Add(enemyController);
           controllers.Add(genCtrl);
           controllers.Add(questCfgController);
        }
    }
}