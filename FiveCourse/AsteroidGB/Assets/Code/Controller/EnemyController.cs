using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

namespace AsteroidGB
{
    public class EnemyController: IOnStart, IController
    {
        private EnemyModel _enemyModel;
        private FactoryEnemy _factoryEnemy;
        
        private List<EnemyView> _enemies = new List<EnemyView>();

        //TODO сделать выбор количества врагов
        private int COUNT = 5;
        public EnemyController(EnemyModel enemyModel, FactoryEnemy enemyFactory)
        {
            _enemyModel = enemyModel;
            _factoryEnemy = enemyFactory;
            for (int i = 0; i < COUNT; i++)
            {
                var enemy = _factoryEnemy.CreateEnemy((Enemys)Range(0, Enum.GetNames(typeof(Enemys)).Length));
                _enemies.Add(enemy);
            }
        }

        public void OnStart()
        {
            foreach (var ell in _enemies)
            {
                var randomVect = new Vector3(Range(-1f,1f), Range(-1f,1f), 0);
                ell.GetComponent<Rigidbody>().AddForce(randomVect.normalized*Range(_enemyModel._minSpeed, _enemyModel._maxSpeed), ForceMode.Impulse);
            }
        }
    }
}