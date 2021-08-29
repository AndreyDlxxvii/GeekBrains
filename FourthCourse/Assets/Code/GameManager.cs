using System;
using System.Collections;
using Code.MVC;
using Code.MVC.View;
using GeekBrainsHW;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Text ScoreText;
        [SerializeField] private Text TimerText;
        [SerializeField] private Text GameOverText;
        
        public Camera Camera;
        public Animator ButtonRestart;
        public Button RestartButton;

        private int _score = 0;
        private SmoothFollow _smoothFollow;
        private static readonly int New = Animator.StringToHash("New");
        private ImmortalBonus _myBonus;
        private static readonly int RestartButtonShow = Animator.StringToHash("RestartButtonShow");
        private bool _checkFinish = false;
        private bool _checkGameOver = false;
        private bool _checkBonus = false;
        private ShowScore _showScore;
        private ShowTimer _showTimer;
        private ShowTextGame _showTextGame;

        private void Awake()
        {
            _smoothFollow = Camera.GetComponent<SmoothFollow>();
            _showScore = new ShowScore(ScoreText, _score);
            _showTimer = new ShowTimer(TimerText, 0);
            _showTextGame = new ShowTextGame(GameOverText);
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
                GameOverText.gameObject.SetActive(true);
                _showTextGame.ShowWinText("Сongratulations!");
                RestartGame();
            };
        }
 

        public void IncrementalScore()
        {
            FindObjectOfType<PlayerView>().GetCoin += () =>
            {
                _score++;
                _showScore.Show(_score);
            };
        }
        

        private void PrintTimer()
        {
            _myBonus = FindObjectOfType<ImmortalBonus>();
            _myBonus.GetUpBonus += (b, n)=>
            {
                _checkBonus = b;
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
                _myBonus.GetUpBonus -= (b, timer) => { };
            }
        }

        public void CheckGameOver()
        {
            var player = FindObjectOfType<PlayerView>();
            player.MyGameOver += () =>
            {
                if (_checkBonus)
                {
                    player.transform.position = new Vector3(-5f,-16.7f,37f);
                }
                else
                {
                    _smoothFollow.enabled = false;
                    GameOverText.gameObject.SetActive(true);
                    _showTextGame.ShowWinText("Game Over");
                    if (player is { }) player.MyGameOver -= () => { };
                    RestartGame();  
                }
            };
            
        }

        private void RestartGame()
        {
            if (FindObjectOfType<PlayerView>() != null)
            {
                var t = FindObjectOfType<PlayerView>();
                t.gameObject.SetActive(false);
            }
            ButtonRestart.SetInteger(RestartButtonShow, 0);
            RestartButton.onClick.AddListener(RestartGameButton);
        }

        private void RestartGameButton()
        {
            RestartButton.onClick.RemoveAllListeners();
            SceneManager.LoadScene(0);
        }
    }
}
