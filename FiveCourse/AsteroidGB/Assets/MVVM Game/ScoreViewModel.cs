using System;

namespace MVVM_Game
{
    public class ScoreViewModel
    {
        public ScoreModel ScoreModel;
        public event Action<int> OnHitEnter; 

        public ScoreViewModel(ScoreModel scoreModel)
        {
            ScoreModel = scoreModel;
        }

        public void ChangeScore(int i)
        {
            ScoreModel.Score += i;
            OnHitEnter?.Invoke(ScoreModel.Score);
        }
    }
}