using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeGeek
{
    public class GameManager : MonoBehaviour
    {
        
        public Camera Camera;
        public Animator ButtonRestart;
        public Button RestartButton;

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

        private void Awake()
        {
            _refResources = new RefResources();
            _playerView = FindObjectOfType<PlayerView>();
            _smoothFollow = Camera.GetComponent<SmoothFollow>();
            _showScore = new ShowScore(_refResources.Score, Score);
            _showTimer = new ShowTimer(_refResources.BonusTimer, 0);
            _showTextGame = new ShowTextGame(_refResources.GameOver);
        }

        private void Start()
        {
            PrintTimer();
            FinishGame();
            IncrementalScore();
            CheckGameOver();
        }

        private void FinishGame()
        {
            FindObjectOfType<Finish>().FinishGame += () =>
            {
                _showTextGame.ShowWinText("Сongratulations!");
                RestartGame();
            };
        }
        
        public void IncrementalScore()
        {
            _playerView.GetCoin += () =>
            {
                Score++;
                _showScore.Show(Score);
            };
            _playerView.GetCoin -= () => { };
        }

        private void PrintTimer()
        {
            _myBonus = FindObjectOfType<ImmortalBonus>();
            _myBonus.GetUpBonus += ( n)=>
            {
                _checkBonus = true;
                StartCoroutine(MyTimer(n));
            };
        }

        private IEnumerator MyTimer(int i)
        {
            while (i!=-1)
            {
                _showTimer.Show(i);
                yield return new WaitForSeconds(1f);
                i--;
            }
            if (_myBonus is { })
            {
                _checkBonus = false;
                _myBonus.GetUpBonus -= (timer) => { };
            }
        }

        public void CheckGameOver()
        {
            _playerView.MyGameOver += () =>
            {
                if (_checkBonus)
                {
                    _playerView.transform.position = new Vector3(-5f,-16.7f,37f);
                }
                else
                {
                    _smoothFollow.enabled = false;
                    _showTextGame.ShowWinText("Game Over");
                    _playerView.MyGameOver -= () => { };
                    RestartGame();  
                }
            };
            
        }

        private void RestartGame()
        {
            if (_playerView != null)
            {
                _playerView.gameObject.SetActive(false);
            }
            ButtonRestart.SetInteger(RestartButtonShow, 0);
            RestartButton.onClick.AddListener(RestartGameButton);
            FindObjectOfType<Finish>().FinishGame -= () => { };
        }

        private void RestartGameButton()
        {
            RestartButton.onClick.RemoveAllListeners();
            SceneManager.LoadScene(0);
        }
    }
}
