using System;
using GeekBrainsHW;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GeekBrainsHW
{
    public class GameManager : MonoBehaviour
    {
        public Text ScoreText;
        public Text GameOverText;
        public Camera Camera;
        public Animator ButtonRestart;
        public Button RestartButton;

        private GameObject _player;
        private int _i = 0;
        private SmoothFollow _smoothFollow;
        private Player _controlPlayer;
        private static readonly int New = Animator.StringToHash("New");

        void Start()
        {
            _smoothFollow = Camera.GetComponent<SmoothFollow>();
        }
        //Обмен двух чисел
        // private void OnValidate()
        // {
        //     new ChangeTwoNumbers().Changes();
        // }

        public void IncrementalScore()
        {
            _i++;
            ScoreText.text = $"Score: {_i}";

        }

        public void CheckGameOver()
        {
            _smoothFollow.enabled = false;
            GameOverText.text = $"Game Over!";
            RestartGame();
        }
        public void Finish()
        {
            _controlPlayer = FindObjectOfType<Player>().GetComponent<Player>();
            GameOverText.text = $"Сongratulations!";
            _controlPlayer.enabled = false;
            RestartGame();
        }
        private void RestartGame()
        {
            GameOverText.gameObject.SetActive(true);
            ButtonRestart.SetInteger("RestartButtonShow", 0);
            RestartButton.onClick.AddListener(() => RestartGameButton());
        }

        public void RestartGameButton()
        {
            SceneManager.LoadScene(0);
            RestartButton.onClick.RemoveAllListeners();
        }
    }
}
