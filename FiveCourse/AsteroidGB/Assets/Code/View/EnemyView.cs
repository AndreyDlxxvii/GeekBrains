using System;
using UnityEngine;

namespace AsteroidGB
{
    public class EnemyView : MonoBehaviour, IEnemy
    {
        public event Action OnDeath; 
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                OnDeath?.Invoke();
                Destroy(gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Respawn"))
            {
                var i = transform.position;
                transform.position = i * -1;
            }
        }
    }
}