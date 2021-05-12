using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMover : MonoBehaviour
{
    public Transform trans;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 q = new Vector3(trans.position.x+0.3f, trans.position.y, trans.position.z);
        transform.position = q;
    }
}
