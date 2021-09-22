using UnityEngine;
using UnityEngine.UI;

namespace CodeGeek
{
    public class RefResources
    {
        private Text _scoreText;
        private Text _gameOverText;
        private Text _bonusTimerText;
        private Canvas _canvas;

        public Text Score
        {
            get
            {
                var ell = Object.Instantiate(Resources.Load<GameObject>("UI/Score"), Canvas.transform);
                return _scoreText = ell.GetComponent<Text>();
            }
        }

        public Text GameOver
        {
            get
            {
                var ell = Object.Instantiate(Resources.Load<GameObject>("UI/GameOverText"), Canvas.transform);
                return _gameOverText = ell.GetComponent<Text>();
            }
        }

        public Text BonusTimer
        {
            get
            {
                var ell = Object.Instantiate(Resources.Load<GameObject>("UI/BonusTimer"), Canvas.transform);
                return _bonusTimerText = ell.GetComponent<Text>();
            }
        }

        public Canvas Canvas
        {
            get
            {
                _canvas = Object.FindObjectOfType<Canvas>();
                return _canvas;
            }
            
        }
    }
}