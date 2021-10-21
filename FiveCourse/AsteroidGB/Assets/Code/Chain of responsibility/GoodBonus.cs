using System;
using AsteroidGB.Chain_of_responsibility;
using UnityEngine;

namespace AsteroidGB
{
    public class GoodBonus : MonoBehaviour
    {
        public event Action<int> GETBonus;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerView>())
            {
                GETBonus?.Invoke(1);
            }
        } 
    }
}