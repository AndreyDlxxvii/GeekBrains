using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Control1 : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 100f;
    public Transform Gun;
    public Transform GunPoint;
    public GameObject Bullet;
    public float Sensitivity;
    public Text Helth;
    public Text Ammo;
    
    private bool _isGrounded;
    private Rigidbody _rb;
    private byte _countCheckGround;
    private int _countOfShell=5;
    private int _helthPlayer = 100;

    private void Awake()
    {
        Helth.text = $"Helth: {_helthPlayer}";
        Ammo.text = $"Ammo: {_countOfShell}";
    }


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotateGun();
        Fire();
    }
    
    void FixedUpdate()
    {
        Jump();
        Movement();
        
    }

    private void RotateGun()
    {
        var position = transform.position;
        Gun.transform.position = new Vector3(position.x, position.y, position.z);
        Gun.Rotate(0, Input.GetAxis("Mouse X") * Sensitivity, 0);
        //Gun.eulerAngles = new Vector3(Gun.rotation.eulerAngles.x, Gun.rotation.eulerAngles.y, 0);
    }
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        _rb.AddForce(Gun.forward*Speed*moveVertical);
        _rb.AddForce(Gun.right*Speed*moveHorizontal);
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && _countCheckGround>0)
        {
            _rb.velocity = Vector3.up * JumpForce;
            //_rb.AddForce(Vector3.up * JumpForce);
        }
    }
    
    private void Fire()
    {
        //Debug.DrawRay(GunPoint.position,Gun.forward*1000f,Color.black);
        if (Input.GetButtonDown("Fire1") && _countOfShell!=0)
        {
            Instantiate(Bullet, GunPoint.position, Gun.rotation);
            _countOfShell--;
            Ammo.text = $"Ammo: {_countOfShell}";
        }
    }
    //check on ground
    void OnCollisionEnter (Collision collision)
    {
        var temp = collision.gameObject.tag;
            switch (temp)
            {
                case "Ground":
                    _countCheckGround++;
                    break;
                case "Ammo":
                    _countOfShell += 5;
                    Ammo.text = $"Ammo: {_countOfShell}";
                    break;
                case "Mine":
                    _helthPlayer -= 10;
                    Helth.text = $"Helth: {_helthPlayer}";
                    break;
                case "Aid":
                    _helthPlayer += 10;
                    Helth.text = $"Helth: {_helthPlayer}";
                    break;
                case "Bullet":
                    _helthPlayer -= 5;
                    Helth.text = $"Helth: {_helthPlayer}";
                    break;
            }
        } 
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _countCheckGround--;
    } 
    
}

