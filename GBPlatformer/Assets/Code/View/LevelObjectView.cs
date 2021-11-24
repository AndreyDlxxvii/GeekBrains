using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{ 
    public class LevelObjectView : MonoBehaviour
    {
        public Transform Transform;
        public SpriteRenderer SpriteRenderer;
        public Collider2D Collider2D;
        public Rigidbody2D Rigidbody2D;

        public Action<CoinObjectView> OnLevelObject { get; set; }
        private void Awake()
        {
            if (Transform == null) Transform = GetComponent<Transform>();
            if (SpriteRenderer == null) SpriteRenderer = GetComponent<SpriteRenderer>();
            if (Collider2D == null) Collider2D = GetComponent<Collider2D>();
            if (Rigidbody2D == null) Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var levelObj = other.gameObject.GetComponent<CoinObjectView>();
            OnLevelObject?.Invoke(levelObj);
        }
    }
    
}
