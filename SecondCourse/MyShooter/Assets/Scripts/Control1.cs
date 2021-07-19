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
    public bool KeyIsUp;
    public GameObject Mine;
    public Animator Heart;
    public Light GunFlash;
    
    public int HealthPlayer { get=>_helthPlayer; private set => _helthPlayer = value; }
    public int AmmoPlayer { get => _countOfAmmo; private set => _countOfAmmo = value; }
    
    private bool _isGrounded;
    private Rigidbody _rb;
    private byte _countCheckGround;
    private int _countOfAmmo = 30;
    private int _helthPlayer = 100;
    private int _maxHelth = 100;
    private float _reloadTime;
    private GameManager _gameManager;
    private float _jumpTime;
    private float _time;
    private bool _immortal;
    private bool _infinAmmo;
    private AudioSource _shootPlayer;
    private float lightFlash = 10f;

    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        HealthPlayer = _helthPlayer;
        AmmoPlayer = _countOfAmmo;
        _shootPlayer = Gun.gameObject.GetComponent<AudioSource>();
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
        Jump();
    }
    
    void FixedUpdate()
    {
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
            _gameManager.EndOfGame(false);
        }
    }

    private void Jump()
    {
         if (Input.GetKey(KeyCode.Space) && _countCheckGround>0)
         {
             if ((_jumpTime +=Time.fixedDeltaTime) > 1f)
             {
                 _rb.velocity = Vector3.up * JumpForce * 1.2f;
                 _jumpTime = 0f;
             }
         }
         else if (Input.GetKeyUp(KeyCode.Space) && _countCheckGround>0)
         {
             _rb.velocity = Vector3.up * JumpForce;
             _jumpTime = 0f;
         }
    }
    
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1") && _countOfAmmo!=0)
        {
            Instantiate(Bullet, GunPoint.position, Gun.rotation);
            _shootPlayer.Play();
            _countOfAmmo--;
            StartCoroutine(Flash());
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
                    _countOfAmmo += 5;
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
                // case "Key":
                //     KeyIsUp = true;
                //     break;
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
        if (_helthPlayer<=0)
        {
            _gameManager.EndOfGame(false);
        }
    }

    public void HealPlayer(int heal)
    {
        _helthPlayer = Mathf.Clamp(_helthPlayer + heal, 0, _maxHelth);
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
            if ((_time +=Time.deltaTime) > 30f)
            {
                _immortal = false;
            }
        }

        if (_infinAmmo)
        {
            _countOfAmmo = 30;
            if ((_time +=Time.deltaTime) > 30f)
            {
                _infinAmmo = false;
            }
        }
    }

    IEnumerator Flash()
    {
        GunFlash.intensity = lightFlash;
        yield return new WaitForSeconds(0.1f);
        GunFlash.intensity = 0f;
    }
}

