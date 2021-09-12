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
        private GameObject _coinPrefab;
        private Camera _mainCamera;
        private Button _restartButton;


        public Button RestartButton
        {
            get
            {
                var restartButton = Object.Instantiate(Resources.Load<Button>("UI/Button"), Canvas.transform);
                return restartButton;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }

                return _mainCamera;
            }
        }

        public GameObject CoinPrefab
        {
            get 
            {
                if (_coinPrefab == null)
                {
                    _coinPrefab = Object.Instantiate(Resources.Load<GameObject>("GoldCoin"));
                }
                return _coinPrefab;
            }
        }

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