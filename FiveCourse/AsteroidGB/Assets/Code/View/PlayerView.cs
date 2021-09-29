using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AsteroidGB
{
    internal class PlayerView : MonoBehaviour
    {
        
        private Rigidbody2D _playerRigidbody2D;

        public Transform GunPosition
        {
            get
            {
                var q = transform.Find("GunPoint");
                return q;
            }
        }

        private Vector2 _movement;

        private void OnTriggerEnter(Collider other)
        {
        }
    }
}

