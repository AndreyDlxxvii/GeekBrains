using System;
using AsteroidGB.Chain_of_responsibility;

namespace AsteroidGB
{
    public class GameInit
    {
        public GameInit(RefResources resources, Controllers controllers)
        {
            var userInterface = new UserInterface();
            var player = new CreatePlayer(resources.PlayerPrefab).PlayerMonoBeh();
            var enemyFactory = new FactoryEnemy(resources);
            var playerModel = new PlayerModel(100f, 5f, 2f);
            var observerController = new ObserverController(new Observer(), player);
            var playerController = new PlayerController(playerModel, player);
            var enemyController = new EnemyController(new EnemyModel(1f, 3f), enemyFactory);
            var ufoController = new UFOController(new UFOModel(2f, 100f), enemyFactory);
            var scoreCountController = new ScoreCountController(enemyController, ufoController);
            var chainController = new ChainOfResponsController(new FirstBonusHandler(), new SecondBonusHandler());


            controllers.Add(observerController);
            controllers.Add(userInterface);
            controllers.Add(scoreCountController);
            controllers.Add(playerController);
            controllers.Add(enemyController);
            controllers.Add(ufoController);
            controllers.Add(chainController);
        }
    }
}