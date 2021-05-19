using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUp : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up*Time.deltaTime*20f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           Destroy(gameObject);
        }
    }
}
