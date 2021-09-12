using System;
using UnityEngine;

namespace CodeGeek
{
    public class CoinView : MonoBehaviour
    {
        public void FlayPingPong(float val)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, val),
                transform.localPosition.z);
        }
    }
}