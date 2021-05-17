using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
        
        Destroy(gameObject, 2f);
    }
}
