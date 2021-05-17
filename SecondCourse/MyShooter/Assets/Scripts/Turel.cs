using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turel : MonoBehaviour
{
   
    public float Speed = 5f;
    public float MinDistance = 10f;
    public GameObject Bullet;

    private OpenSecondDoor _secondDoor;
    private float _timer;
    private Transform _transformTower;
    private Transform _transformGun;
    private Transform Target;
    
    private void Awake()
    {
        _transformTower = transform.GetChild(1);
        _transformGun = _transformTower.GetChild(1);
        _secondDoor = GameObject.Find("SecondDoor").GetComponent<OpenSecondDoor>();
        Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        if (Vector3.Distance(_transformTower.position, Target.position) < MinDistance )
        {
            Vector3 vect = Target.position - _transformTower.position;
            Vector3 newDict = Vector3.RotateTowards(_transformTower.forward, vect, Speed * Time.deltaTime, 0f);
            _transformTower.rotation = Quaternion.LookRotation(newDict);
            _timer += Time.deltaTime;
            if (_timer>1)
            {
                Instantiate(Bullet, _transformGun.position, _transformGun.rotation);
                _timer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            _secondDoor.Increase();
        }
    }
}
