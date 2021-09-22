using System;
using UnityEngine;

namespace GeekBrainsHW
{
    public class DestroyCoin : MonoBehaviour, IDisposable

    {
        private void OnTriggerEnter(Collider other)
        {
            Dispose();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }

    
}
