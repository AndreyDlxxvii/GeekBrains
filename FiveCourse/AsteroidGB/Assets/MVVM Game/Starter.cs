using System.Collections;
using System.Collections.Generic;
using AsteroidGB;
using UnityEngine;

namespace MVVM_Game
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private EnemySpawn _enemySpawn;

        void Start()
        {
            var scoreModel = new ScoreModel(0);
            var scoreViewModel = new ScoreViewModel(scoreModel);
            var showScore = new ShowScore(scoreViewModel);
            _playerView.Init(scoreViewModel);
        }

        void Update()
        {
            _enemySpawn.SpawnEnemy(Time.deltaTime);
            _playerView.Move(Time.deltaTime);
        }
    }
}

