using UnityEngine;
using UnityEngine.UI;

namespace AsteroidGB
{
    public class Observer
    {
        public void Add(IOnHit player)
        {
            player.OnHit += Display;
        }

        public void Clean(IOnHit player)
        {
            player.OnHit -= Display;
        }

        public void Display()
        {
            Debug.Log("Попадание в корабль");
        }
    }
}