using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public Light _myFlash;
    public float LightFlash = 10f;

    private void Start()
    {
        //_myFlash = transform.GetComponent<Light>();
    }

    private void OnCollisionEnter(Collision other)
    {
        StartCoroutine(Flash());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 10);
        Destroy(gameObject, 2f);
    }
    
    IEnumerator Flash()
    {
        _myFlash.intensity = LightFlash;
        yield return new WaitForSeconds(0.1f);
        _myFlash.intensity = 0f;
        Destroy(gameObject);
    }
}
