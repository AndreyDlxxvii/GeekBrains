using System;

namespace AsteroidGB
{
    public class GameInit
    {
        public GameInit(RefResources resources, Controllers controllers)
        {
            var player = new CreatePlayer(resources.PlayerPrefab);
            var enemyFactory = new FactoryEnemy(resources);
            var playerController = new PlayerController(new PlayerModel(100f, 5f, 2f), player.PlayerMonoBeh());
            var enemyController = new EnemyController(new EnemyModel(1f, 3f), enemyFactory);
            var UFOController = new UFOController(new UFOModel(2f, 100f), enemyFactory.CreateEnemy(Enemys.UFO));
            
            
            

            controllers.Add(playerController);
            controllers.Add(enemyController);
            controllers.Add(UFOController);
        }
    }
}