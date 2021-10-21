using System;
using AsteroidGB.Chain_of_responsibility;

namespace AsteroidGB
{
    public class GameInit
    {
        public GameInit(RefResources resources, Controllers controllers)
        {
            var userInterface = new UserInterface();
            var player = new CreatePlayer(resources.PlayerPrefab);
            var enemyFactory = new FactoryEnemy(resources);
            var playerModel = new PlayerModel(100f, 5f, 2f);
            var playerController = new PlayerController(playerModel, player.PlayerMonoBeh());
            var enemyController = new EnemyController(new EnemyModel(1f, 3f), enemyFactory);
            var UFOController = new UFOController(new UFOModel(2f, 100f), enemyFactory);
            var scoreCountController = new ScoreCountController(enemyController, UFOController);
            var chainController = new ChainOfResponsController(new FirstBonusHandler(), new SecondBonusHandler());



            controllers.Add(userInterface);
            controllers.Add(scoreCountController);
            controllers.Add(playerController);
            controllers.Add(enemyController);
            controllers.Add(UFOController);
            controllers.Add(chainController);
        }
    }
}