using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControl : MonoBehaviour
{
    private float _speed = 0.02f;
    private void FixedUpdate()
    {
        print(transform.position.y);
       // MoveLift();
    }

    // private void MoveLift()
    // {
    //     if (transform.position.y)
    //     {
    //         transform.Translate(Vector3.up * _speed);
    //     }
    // }
}
