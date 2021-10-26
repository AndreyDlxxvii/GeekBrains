namespace MVVM_Game
{
    public class ScoreModel 
    {
        public int CurrentScore { get; }
        public int Score { get; set; }

        public ScoreModel(int score)
        {
            Score = score;
            CurrentScore = Score;
        }
    }
    
}

