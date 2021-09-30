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
                var point = transform.Find("GunPoint");
                return point;
            }
        }

        private Vector2 _movement;

        private void OnTriggerEnter(Collider other)
        {
        }
    }
}

