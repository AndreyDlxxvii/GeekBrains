using UnityEngine;

namespace CodeGeek
{
    public class Finish : MonoBehaviour
    {
        public delegate void CheckFinish();

        public event CheckFinish FinishGame;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FinishGame?.Invoke();
            }
        }
    }
}



