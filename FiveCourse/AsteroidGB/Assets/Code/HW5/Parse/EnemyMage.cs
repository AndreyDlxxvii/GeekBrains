using UnityEngine;

namespace AsteroidGB.HW5.Parse
{
    internal class EnemyMage
    {
        private Units _units;

        public EnemyMage (Units units)
        {
            _units = units;
        }

        public void CreateEnemy()
        {
        
            //Debug.Log("создать мага со здоровьем= " + _units.unit.health);
        } 
    }
    
}
