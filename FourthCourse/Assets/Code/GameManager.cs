using System;
using System.Collections;
using GeekBrainsHW;
using GeekBrainsHW.MVC;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekBrainsHW
{
    public class GameManager : MonoBehaviour
    {
        public Text ScoreText;
        public Text TimerText;
        public Text GameOverText;
        public Camera Camera;
        public Animator ButtonRestart;
        public Button RestartButton;

        private GameObject _player;
        private int _score = 0;
        private SmoothFollow _smoothFollow;
        private Player _controlPlayer;
        private static readonly int New = Animator.StringToHash("New");
        private ImmortalBonus _myBonus;
        private static readonly int RestartButtonShow = Animator.StringToHash("RestartButtonShow");
        private bool _checkFinish = false;

        void Start()
        {
            _smoothFollow = Camera.GetComponent<SmoothFollow>();
            PrintTimer();
            FinishGame();
            IncrementalScore();
        }

        private void FinishGame()
        {
            FindObjectOfType<Finish>().FinishGame += () =>
            {
                _controlPlayer = FindObjectOfType<Player>().GetComponent<Player>();
                GameOverText.text = $"Сongratulations!";
                _controlPlayer.enabled = false;
                RestartGame();
            };
        }
 

        public void IncrementalScore()
        {
            FindObjectOfType<PlayerView>().GetCoin += () =>
            {
                _score++;
                ScoreText.text = $"Score: {_score}";
            };
        }
        

        private void PrintTimer()
        {
            _myBonus = FindObjectOfType<ImmortalBonus>();
            _myBonus.OnTrigger += (b, n)=>
            {
                StartCoroutine(MyTimer(n));
            };
        }

        private IEnumerator MyTimer(int i)
        {
            while (i!=-1)
            {
                TimerText.text = $"Timer: {i}";
                yield return new WaitForSeconds(1f);
                i--;
            }

            if (_myBonus is { }) _myBonus.OnTrigger -= (b, timer) => { };
        }

        public void CheckGameOver()
        {
            _smoothFollow.enabled = false;
            GameOverText.text = $"Game Over!";
            RestartGame();
        }

        private void RestartGame()
        {
            GameOverText.gameObject.SetActive(true);
            ButtonRestart.SetInteger(RestartButtonShow, 0);
            RestartButton.onClick.AddListener(RestartGameButton);
        }

        private void RestartGameButton()
        {
            SceneManager.LoadScene(0);
            RestartButton.onClick.RemoveAllListeners();
        }
    }
}
