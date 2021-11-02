using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGB
{
    public class PlayerView : MonoBehaviour, IOnHit
    {
        public event Action OnHit;
        private Rigidbody2D _playerRigidbody2D;

        public Transform GunPosition
        {
            get
            {
                var point = transform.Find("GunPoint");
                return point;
            }
        }

        private Vector2 _movement;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IEnemy>() != null)
            {
                OnHit?.Invoke();
            }
        }

        
    }
}

