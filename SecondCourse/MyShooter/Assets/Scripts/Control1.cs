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
    public Animator Heart;
    
    private bool _isGrounded;
    private Rigidbody _rb;
    private byte _countCheckGround;
    private int _countOfShell = 30;
    private int _helthPlayer = 100;
    private int _maxHelth = 100;
    private float _reloadTime;
    private GameManager _gameManager;
    private float _jumpTime;
    private bool _jumpFlag;
    private float _time;
    private bool _immortal;
    private bool _infinAmmo;

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
        PickUpImmortalBonus();
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
            if (Input.GetKey(KeyCode.Space) && _countCheckGround>0)
            {
                if ((_jumpTime+=Time.fixedDeltaTime)>1f)
                {
                    _jumpTime = 0f;
                }
            }
            
        // if (Input.GetAxis("Jump")>0)
        // {
        //     if (_countCheckGround>0)
        //     {
        //         _isGrounded = true;
        //     }
        //     else _isGrounded = false;
        // }
        //
        // if (_isGrounded)
        // {
        //     if ((_jumpTime +=Time.fixedDeltaTime)>1f)
        //     {
        //         _rb.velocity = Vector3.up * JumpForce * 1.5f;
        //     }
        //     else
        //     {
        //         _rb.velocity = Vector3.up * JumpForce;
        //     }
        // }
        // if (Input.GetKey(KeyCode.Space) && _countCheckGround>0)
        // {
        //     if ((_jumpTime +=Time.fixedDeltaTime) > 2f)
        //     {
        //         _rb.velocity = Vector3.up * JumpForce * 2f;
        //         _jumpTime = 0f;
        //     }
        //     // else
        //     // {
        //     //     _rb.velocity = Vector3.up * JumpForce;
        //     //     _jumpTime = 0f;
        //     // }
        //}
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
                    Heart.Play("TakeAmmo");
                    break;
                case "Mine":
                    TakeDamage(10);
                    Heart.Play("TakeDamage");
                    break;
                case "Aid":
                    HealPlayer(10);
                    Heart.Play("TakeHeal");
                    break;
                case "BulletEnemy":
                    TakeDamage(5);
                    Heart.Play("TakeDamage");
                    break;
                case "Key":
                    KeyIsUp = true;
                    break;
                case "Immortal":
                    _immortal = true;
                    break;
                case "InfiniteAmmo":
                    _infinAmmo = true;
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
    private void PickUpImmortalBonus()
    {
        if (_immortal)
        {
            _helthPlayer = 100;
            if ((_time +=Time.deltaTime) > 5f)
            {
                _immortal = false;
            }
        }

        if (_infinAmmo)
        {
            _countOfShell = 30;
            if ((_time +=Time.deltaTime) > 5f)
            {
                _infinAmmo = false;
            }
        }
    }
}

