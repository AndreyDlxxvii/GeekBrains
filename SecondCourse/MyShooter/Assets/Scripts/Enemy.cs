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
    
    private void Awake()
    {
        _secondDoor = GameObject.Find("SecondDoor").GetComponent<OpenSecondDoor>();
        Target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _navMesh = GetComponent<NavMeshAgent>();
        _transformGun = transform.GetChild(1);
    }

    private void Start()
    {
        _navMesh.SetDestination(WayPoint[0].position);
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
            // _currentWayPoint = (_currentWayPoint + 1) % WayPoint.Length;
            // _navMesh.SetDestination(WayPoint[_currentWayPoint].position);
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
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            _secondDoor.Increase();
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
