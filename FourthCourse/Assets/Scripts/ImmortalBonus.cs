using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GeekBrainsHW;
using UnityEngine;

public class ImmortalBonus : MonoBehaviour, IDisposable
{
    public delegate void OnTriggered(bool n);
    public event OnTriggered OnTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        OnTrigger?.Invoke(true);
        Dispose();
    }

    public void Dispose()
    {
        Destroy(gameObject);
    }
}
