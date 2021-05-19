using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public Transform Door;
    private bool _flag = false;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _flag = true;
        }
    }
    
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
