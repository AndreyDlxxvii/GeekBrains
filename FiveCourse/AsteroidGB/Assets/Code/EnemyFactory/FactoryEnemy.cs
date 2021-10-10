using Unity.Mathematics;

namespace AsteroidGB
{
    public class FactoryEnemy : IEnemyFactory
    {
        private RefResources _refResources;
        
        public FactoryEnemy(RefResources refResources)
        {
            _refResources = refResources;
        }

        public EnemyView CreateEnemy(Enemys enemy)
        {
            // TODO: Сделать через dictionary
            switch (enemy)
            {
                case Enemys.Asteroid:
                    return new AsteroidEnemyNormal(_refResources.AsteroidPrefab).Create();
                break;
                case Enemys.AsteroidBig:
                    return new AsteroidEnemyBig(_refResources.AsteroidPrefabBig).Create();
                break;
                case Enemys.AsteroidMedium:
                    return new AsteroidEnemySmall(_refResources.AsteroidPrefabMedium).Create();
                break;
                case Enemys.UFO:
                    return new UFO(_refResources.UFO).Create();
                break;
                    
            }

            return null;
        }

    }
}