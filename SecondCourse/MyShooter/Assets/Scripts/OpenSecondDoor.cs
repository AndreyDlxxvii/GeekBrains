using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSecondDoor : MonoBehaviour
{
    private int _count = 0;

    void Update()
    {
        
        if (_count>7)
        {
            if (transform.position.x>-1f)
            {
                transform.Translate(Vector3.left*Time.deltaTime);
            } 
        }
    }

    public void Increase()
    {
        _count++;
    }
}
