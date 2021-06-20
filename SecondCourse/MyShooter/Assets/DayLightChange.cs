using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayLightChange : MonoBehaviour
{
    [Range(0, 1)]
    public float DayTime;
    public float DayDuration = 30f;
    public Light Sun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DayTime += Time.deltaTime / DayDuration;
        Sun.transform.localRotation = Quaternion.Euler(DayTime*360f, 180, 0);
        if (DayTime >= 1f)
        {
            DayTime -= 1f;
        }
    }
}
