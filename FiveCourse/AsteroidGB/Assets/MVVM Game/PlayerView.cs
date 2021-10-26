using System;
using UnityEngine;

namespace MVVM_Game
{
    public class PlayerView : MonoBehaviour
    {
        
        private ScoreViewModel ScoreViewModel;
        
        public void Init(ScoreViewModel scoreViewModel)
        {
            ScoreViewModel = scoreViewModel;
        }

        public void Move(float deltaTime)
        {
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * 5f * deltaTime);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * 5f * deltaTime);

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                ScoreViewModel.ChangeScore(1);
                Destroy(other.gameObject);
            }
            else
            {
                ScoreViewModel.ChangeScore(-1);
                Destroy(other.gameObject);
            }
            
        }
    }
}