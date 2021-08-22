using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public delegate void CheckFinish();

    public event CheckFinish FinishGame;

    private void OnTriggerEnter(Collider other)
    {
        FinishGame?.Invoke();
    }
}


