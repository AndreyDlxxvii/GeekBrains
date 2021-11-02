using UnityEngine;

namespace AsteroidGB
{
    public interface IEnemyFactory
    {
        EnemyView CreateEnemy(Enemys exampleOfEnemy);
    }
}