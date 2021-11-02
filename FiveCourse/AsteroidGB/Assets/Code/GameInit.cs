using System;

namespace AsteroidGB
{
    public class GameInit
    {
        public GameInit(RefResources resources, MyControllers myControllers)
        {
            var player = new CreatePlayer(resources.PlayerPrefab);
            var enemyFactory = new FactoryEnemy(resources);
            var playerController = new PlayerController(new PlayerModel(100f, 5f, 2f), player.PlayerMonoBeh());
            var enemyController = new EnemyController(new EnemyModel(1f, 3f), enemyFactory);
            // Клонирование через прототип
            // var t = new UFOModel(2f, 100f);
            // var q = t.DeepCopy();
            var UFOController = new UFOController(new UFOModel(2f, 100f), enemyFactory.CreateEnemy(Enemys.UFO));
            
            
            

            myControllers.Add(playerController);
            myControllers.Add(enemyController);
            myControllers.Add(UFOController);
        }
    }
}