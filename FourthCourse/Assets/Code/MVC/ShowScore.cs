using UnityEngine;
using UnityEngine.UI;

namespace Code.MVC
{
    public sealed class ShowScore
    {
        private Text _scoreText;

        public ShowScore(Text testScore, int score)
        {
            _scoreText = testScore;
            _scoreText.text = $"Score: {score}";
        }

        public void Show(int score)
        {
            _scoreText.text = $"Score: {score}";
        }
    }
}