using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftControl : MonoBehaviour
{
    private float _speed = 0.5f;
    private bool _flag;
    private void FixedUpdate()
    {
        if (_flag&& transform.position.y<17f)
        {
            MoveLift();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _flag = true;
        }
    }
    private void MoveLift()
    {
        transform.Translate(Vector3.up * (_speed * Time.fixedDeltaTime));
    }
}
