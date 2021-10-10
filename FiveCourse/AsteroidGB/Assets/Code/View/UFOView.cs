using UnityEngine;

namespace AsteroidGB
{
    public class UFOView : EnemyView
    {
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