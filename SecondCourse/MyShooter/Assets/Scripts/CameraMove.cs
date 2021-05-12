using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform trans;

    void Update()
    {
        Vector3 q = new Vector3(trans.position.x, trans.position.y + 2f, trans.position.z - 2.5f);
        transform.position = q;
    }
}
