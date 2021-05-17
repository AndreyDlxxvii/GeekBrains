using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public Transform Door;
    

    private bool _flag = false;
    // Start is called before the first frame update
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         _flag = true;
    //     }
    // }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _flag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_flag) DoorOpen();
    }

    private void DoorOpen()
    {
        if (Door.transform.position.x>-1f)
        {
            Door.Translate(Vector3.left*Time.deltaTime);
        }
    }
}
