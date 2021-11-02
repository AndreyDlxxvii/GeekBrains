using UnityEngine;
using UnityEngine.UI;

namespace MVVM_Game
{
    public class ShowScore
    {
        private ScoreViewModel _scoreViewModel;

        public ShowScore(ScoreViewModel scoreViewModel)
        {
            _scoreViewModel = scoreViewModel;
            _scoreViewModel.OnHitEnter += PrintScore;
        }

        private void PrintScore(int i)
        {
            Debug.Log(i);
        }
        
    }
}