using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekBrainsHW
{
    public class SpawnCoin : MonoBehaviour
    {
        public GameObject prefab;
        void Start()
        {
           SpawnGoldCoinOnScene();
        }
//spawn coin as child platform
        private void SpawnGoldCoinOnScene()
        {
            foreach (Transform child in transform)
            {
                var position = child.transform.TransformPoint(0f,0.5f,0f);
                var obj = Instantiate(prefab);
                obj.transform.position = position;
                obj.transform.SetParent(child);
            }
        }

    }
}

