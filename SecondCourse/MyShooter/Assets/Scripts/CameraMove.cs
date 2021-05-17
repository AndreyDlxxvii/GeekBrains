using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform trans;
    
    void Update()
    {
        transform.position = new Vector3(trans.position.x, trans.position.y, trans.position.z);
        transform.rotation = Quaternion.Euler(trans.rotation.x, trans.rotation.y, trans.rotation.z);
    }
}
