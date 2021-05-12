using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Serialization;

public class Control : MonoBehaviour
{
    //public GameManager GameManager;
    public float Speed = 2f;
    public float Sensitivity = 5f;
    public GameObject Bullet;
    public Transform GunPoint;

    private bool _isGrounded;
    private Rigidbody _rb;
    private byte _countCheckGround;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, GunPoint.position, GunPoint.rotation);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement*Speed*Time.fixedDeltaTime);
        transform.GetChild(1).Rotate(0,Input.GetAxis("Mouse X") * Sensitivity,0);
        var q = Input.mousePosition.x;
    }
}

