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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            other.gameObject.GetComponent<Control1>().KeyIsUp = true;
            Destroy(gameObject);
        }
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //        Destroy(gameObject);
    //     }
    // }
}
