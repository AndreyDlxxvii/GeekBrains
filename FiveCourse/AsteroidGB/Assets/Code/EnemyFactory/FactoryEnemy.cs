using System.Collections.Generic;
using AsteroidGB.Iterator;
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
            //Тестовое применение итератора
            var ability = new List<IAbility>
            {
                new EnemyAbility("НЛО", 1),
                new EnemyAbility("Еще что-то", 2),
                new EnemyAbility("и что-то еще", 3)
            };
            // var testAbiliry = new UFO(_refResources.UFO, ability);
            // var test = testAbiliry.GetAbilities("НЛО");
            // var testSecond = testAbiliry.GetEnumerator();
            // var testThird = testAbiliry.GetAbility();



            // TODO: Сделать через dictionary
            switch (enemy)
            {
                case Enemys.Asteroid:
                    return new AsteroidEnemyNormal(_refResources.AsteroidPrefab).Create();
                case Enemys.AsteroidBig:
                    return new AsteroidEnemyBig(_refResources.AsteroidPrefabBig).Create();
                case Enemys.AsteroidMedium:
                    return new AsteroidEnemySmall(_refResources.AsteroidPrefabMedium).Create();
                case Enemys.UFO:
                    return new UFO(_refResources.UFO, ability).Create();
            }
            return null;
        }

    }
}