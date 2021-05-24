using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Control1 : MonoBehaviour, ITakeDamage
{
    public float Speed = 5f;
    public float JumpForce = 1f;
    public Transform Gun;
    public Transform GunPoint;
    public GameObject Bullet;
    public float Sensitivity;
    public Text Helth;
    public Text Ammo;
    public bool KeyIsUp;
    public GameObject Mine;

    private bool _isGrounded;
    private Rigidbody _rb;
    private byte _countCheckGround;
    private int _countOfShell = 30;
    private int _helthPlayer = 100;
    private int _maxHelth = 100;
    private float _reloadTime;
    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Helth.text = $"Helth: {_helthPlayer}";
        Ammo.text = $"Ammo: {_countOfShell}";
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotateGun();
        Fire();
        InstalMine();
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
    }
    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        _rb.AddForce(Gun.forward*Speed*moveVertical);
        _rb.AddForce(Gun.right*Speed*moveHorizontal);
        if (transform.position.y<-1f)
        {
            _gameManager.EndOfGame();
        }
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && _countCheckGround>0)
        {
           _rb.AddForce(Vector3.up.normalized * JumpForce);
        }
    }
    
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && _countOfShell!=0)
        {
            Instantiate(Bullet, GunPoint.position, Gun.rotation);
            _countOfShell--;
            Ammo.text = $"Ammo: {_countOfShell}";
        }
    }
    
    private void InstalMine()
    {
        _reloadTime += Time.deltaTime;
        if (Input.GetButtonDown("Fire2")&&_reloadTime>3f)
        {
            var t = Instantiate(Mine, GunPoint.position, Gun.rotation);
            t.GetComponent<Rigidbody>().AddForce(t.transform.forward.normalized*3f);
            _reloadTime = 0f;
        }
    }
    
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
                    TakeDamage(10);
                    break;
                case "Aid":
                    HealPlayer(10);
                    break;
                case "BulletEnemy":
                    TakeDamage(5);
                    break;
                case "Key":
                    KeyIsUp = true;
                    break;
            }
        }

    public void TakeDamage(int damage)
    {
        _helthPlayer = Mathf.Clamp(_helthPlayer - damage, 0, _maxHelth);
        Helth.text = $"Helth: {_helthPlayer}";
        if (_helthPlayer<=0)
        {
            _gameManager.EndOfGame();
        }
    }

    public void HealPlayer(int heal)
    {
        _helthPlayer = Mathf.Clamp(_helthPlayer + heal, 0, _maxHelth);
        Helth.text = $"Helth: {_helthPlayer}";
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _countCheckGround--;
    } 
    
}

