using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Distance = 2.0f;
    public float Height = 1.0f;
    public float HeightDamping = 2.0f;
    public float RotationDamping = 3.0f;
    public Transform Target;

    private void LateUpdate()
    {
        if (!Target)
        {
            return;
        }

        float wantedRotationAngle = Target.eulerAngles.y;
        float wantedHeight = Target.position.y + Height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, RotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, HeightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        var pos = transform.position;
        pos = Target.position - currentRotation * Vector3.forward * Distance;
        pos.y = currentHeight;
        transform.position = pos;

        transform.LookAt(Target);
    }

}
