using System;
using UnityEngine;

namespace AsteroidGB
{
    public class EnemyView : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(123);
        }
    }
}