using System;
using UnityEngine;

namespace Code.MVC.View
{
    public class CoinView : MonoBehaviour, IDisposable
    {
        public void FlayPingPong(float val)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, val),
                transform.localPosition.z);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}