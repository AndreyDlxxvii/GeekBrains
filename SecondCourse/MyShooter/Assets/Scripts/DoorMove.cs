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
        if (other.gameObject.tag!="Untagged")
        {
            if (Door.transform.position.x>-1f)
            {
                _flag = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("OpenDoor"))
        {
            if (Door.transform.position.x<0f)
            {
                _flag = false;
            }
        }
    }

    private void Update()
    {
        if (_flag && Door.transform.position.x>-1f)
        {
            Door.Translate(Vector3.left*Time.deltaTime);
        }
        else if (!_flag && Door.transform.position.x < 0f)
        {
            Door.Translate(Vector3.right*Time.deltaTime);
        }
    }
}
