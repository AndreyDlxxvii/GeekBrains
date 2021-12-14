using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public event Action Hit;
    public event Action Dest;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2f)
        {
            // Dest?.Invoke();
            // Hit?.Invoke();
            timer = 0f;
            gameObject.SetActive(false);
        }
    }
}
