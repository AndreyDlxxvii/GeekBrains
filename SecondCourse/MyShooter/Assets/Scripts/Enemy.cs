using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, ITakeDamage
{
   
    public float Speed = 5f;
    public float MinDistance = 10f;
    public GameObject Bullet;
    public Transform [] WayPoint;

    private OpenSecondDoor _secondDoor;
    private float _timer;
    private Transform _transformTower;
    private Transform _transformGun;
    private Transform Target;
    private NavMeshAgent _navMesh;
    private int _currentWayPoint;
    private int _helthEnemy = 10;
    private GameManager _GM;
    private AudioSource _shotAudioSource;
    private bool _dead;
    
    private void Awake()
    {
        _GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _navMesh = GetComponent<NavMeshAgent>();
        _transformGun = transform.GetChild(1);
        _shotAudioSource = _transformGun.gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (WayPoint.Length > 0)
        {
            _navMesh.SetDestination(WayPoint[0].position);
        }
    }

    void Update()
    {
        RotateToTarget();
        WalkOnWayPoint();
    }

    private void WalkOnWayPoint()
    {
        if (_navMesh.remainingDistance<_navMesh.stoppingDistance)
        {
            _navMesh.SetDestination(WayPoint[Random.Range(0, WayPoint.Length)].position);
        }
    }

    private void RotateToTarget()
    {
        if (Vector3.Distance(transform.position, Target.position) < MinDistance && Target!=null)
        {
            Vector3 vect = Target.position - transform.position;
            Vector3 newDict = Vector3.RotateTowards(transform.forward, vect, Speed * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(newDict);
            _timer += Time.deltaTime;
            if (_timer>1)
            {
                Instantiate(Bullet, _transformGun.position, _transformGun.rotation);
                _timer = 0f;
                _shotAudioSource.Play();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            _GM.IncreaceScore();
        }
    }

    public void TakeDamage(int damage)
    {
        _helthEnemy -= damage;

        if (_helthEnemy<=0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 2f);
        }
    }
}
