using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
