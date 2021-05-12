using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Control : MonoBehaviour
{
    //public GameManager GameManager;
    public float Speed = 2f;
    public float JumpForce = 100f;

    private bool _isGrounded;
    private Rigidbody _rb;
    private byte _countCheckGround;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
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
        transform.rotation = Quaternion.Euler(0f,Input.mousePosition.normalized.x*360f,0f);
        var q = Input.mousePosition.x;
        print(q);
    }
}

