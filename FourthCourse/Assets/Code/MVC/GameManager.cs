using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace CodeGeek
{
    public class GameManager
    {
        
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                _showScore.Show(_score);
            }
        }

        private SmoothFollow _smoothFollow;
        private ImmortalBonus _myBonus;
        private static readonly int RestartButtonShow = Animator.StringToHash("RestartButtonShow");
        private bool _checkBonus = false;
        private ShowScore _showScore;
        private ShowTimer _showTimer;
        private ShowTextGame _showTextGame;
        private int _score;
        private PlayerView _playerView;
        private RefResources _refResources;
        private Button _restartButton;
        private TestCoroutine _coroutine;
        
        public void OnAwake()
        {
            _coroutine = new TestCoroutine();
            _refResources = new RefResources();
            _playerView = Object.FindObjectOfType<PlayerView>();
            _smoothFollow = _refResources.MainCamera.GetComponent<SmoothFollow>();
            _showScore = new ShowScore(_refResources.Score, Score);
            _showTimer = new ShowTimer(_refResources.BonusTimer, 0);
            _showTextGame = new ShowTextGame(_refResources.GameOver);
            _restartButton = _refResources.RestartButton;
        }

        public void OnStart()
        {
            _playerView.GetCoin += IncrementalScore;
            _playerView.MyGameOver += FallPlayer;
            Object.FindObjectOfType<Finish>().FinishGame += FinishGame;
            Object.FindObjectOfType<ImmortalBonus>().GetUpBonus += TakeBonus;
        }

        private void FinishGame()
        {
            _showTextGame.ShowWinText("Сongratulations!");
            RestartGame();
        }
        
        public void IncrementalScore()
        {
            Score++;
            _showScore.Show(Score);
        }

        private void TakeBonus(int i)
        {
            _checkBonus = true;
            _coroutine.StartTestCoroutine(i,_showTimer);
            _coroutine.End += () =>
            {
                _checkBonus = false;
            };
            Object.FindObjectOfType<ImmortalBonus>().GetUpBonus -= TakeBonus;
        }

        private void FallPlayer()
        {
            if (_checkBonus)
            {
                _playerView.transform.position = new Vector3(-5f,-16.7f,37f);
            }
            else
            {
                _smoothFollow.enabled = false;
                _showTextGame.ShowWinText("Game Over");
                RestartGame();  
            }
        }

        private void RestartGame()
        {
            if (_playerView != null)
            {
                _playerView.gameObject.SetActive(false);
            }
            _restartButton.GetComponent<Animator>().SetInteger(RestartButtonShow, 0);
            _restartButton.onClick.AddListener(RestartGameButton);
            CleanUp();
        }

        private void CleanUp()
        {
            _playerView.GetCoin -= IncrementalScore;
            _playerView.MyGameOver -= FallPlayer;
            Object.FindObjectOfType<Finish>().FinishGame -= FinishGame;
        }

        private void RestartGameButton()
        {
            _refResources.RestartButton.onClick.RemoveAllListeners();
            SceneManager.LoadScene(0);
        }
    }
}
