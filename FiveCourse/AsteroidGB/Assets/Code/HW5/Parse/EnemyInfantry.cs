using System;
using UnityEngine;

namespace AsteroidGB.HW5.Parse
{ 
    public class EnemyInfantry
    {
        private Units _units;
        
        public EnemyInfantry(Units units)
        {
            _units = units;
        }
        
        public void CreateEnemy()
        {
        
            Debug.Log("создать пехотинца со здоровьем= " + _units.unit.health);
        } 
    }
}