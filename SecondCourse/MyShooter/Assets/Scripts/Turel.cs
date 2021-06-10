using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turel : MonoBehaviour, ITakeDamage
{
   
    public float Speed = 5f;
    public float MinDistance = 10f;
    public GameObject Bullet;
    
    private OpenSecondDoor _secondDoor;
    private float _timer;
    private Transform _transformTower;
    private Transform _transformGun;
    private Transform Target;
    private int _helthEnemy = 10;
    private GameManager _GM;
    private AudioSource _gunShoot;
    private ParticleSystem _particleSystem;
    private AudioSource _explosionSourse;
    private bool _dead;
    
    private void Awake()
    {
        _transformTower = transform.GetChild(1);
        _transformGun = _transformTower.GetChild(1);
        _secondDoor = GameObject.Find("SecondDoor").GetComponent<OpenSecondDoor>();
        Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _gunShoot = _transformTower.gameObject.GetComponent<AudioSource>();
        _particleSystem = GetComponent<ParticleSystem>();
        _explosionSourse = GetComponent<AudioSource>();
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
            if (_timer>1 && !_dead)
            {
                Instantiate(Bullet, _transformGun.position, _transformGun.rotation);
                _gunShoot.Play();
                _timer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.CompareTag("Bullet"))
        {
            _particleSystem.Play();
            _explosionSourse.Play();
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            _GM.IncreaceScore();
            _dead = true;
            Destroy(gameObject, 2f);
        }
    }
    
    public void TakeDamage(int damage)
    {
        _helthEnemy -= damage;

        if (_helthEnemy<=0)
        {
            Destroy(gameObject);
        }
    }
}
