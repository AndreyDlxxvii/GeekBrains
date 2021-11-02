using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidGB
{
    public class ScoreCountController : IController, IOnStart
    {
        private EnemyController _enemyController;
        private UFOController _ufoController;
        
        private long _score = 0;
        private Text _text;
        private int _count = 0;
        private EnemyView[] _enemyViews;
        
        public ScoreCountController(EnemyController enemyController, UFOController ufoController)
        {
            _enemyController = enemyController;
            _ufoController = ufoController;
            var t = Object.FindObjectOfType<ScoreMarker>();
            _text = t.GetComponent<Text>();
        }

        public void OnStart()
        {
            FindAllEnemys();
        }

         private void FindAllEnemys()
         {
             _enemyViews = Object.FindObjectsOfType<EnemyView>();
             foreach (var ell in _enemyViews)
             {
                 ell.OnDeath += IncreaseScore;
             }
         }

         private void IncreaseScore()
         {
             _score++;
             _text.text = _score.NumReduction();
             if (Object.FindObjectsOfType<EnemyView>().Length == 1)
             {
                 _enemyController.SpawnEnemys(11);
                 _ufoController.Start();
                 FindAllEnemys();
                 
             }
        }
    }
}