using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKeyAcsess : MonoBehaviour
{
    
    void Update()
    {
        transform.Translate(Vector3.left*Time.deltaTime);
        if (transform.position.x < 0)
        {
            transform.Translate(Vector3.left*Time.deltaTime);
        }
        
    }
}
