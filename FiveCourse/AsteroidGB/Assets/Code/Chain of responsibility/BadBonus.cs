using System;
using UnityEngine;

namespace AsteroidGB
{
    public class BadBonus : MonoBehaviour
    {
        public event Action<int> GETBonus;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerView>())
            {
                GETBonus?.Invoke(2);
            }
        }
    }
}