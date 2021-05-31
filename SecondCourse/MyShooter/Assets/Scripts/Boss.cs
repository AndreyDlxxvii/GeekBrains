using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour, ITakeDamage
{
    public float MinDistance = 10f;
    public GameObject Bullet;
    public Transform [] WayPoint;
    public GameObject EnemyBomb;
    
    private float _timer;
    private Transform _transformGun;
    private Transform Target;
    private NavMeshAgent _navMesh;
    private int _currentWayPoint;
    private int _helthEnemy = 200;
    private bool _flag;
    private GameManager _GM;
    
    private void Awake()
    {
        Target = GameObject.FindWithTag("Heart").GetComponent<Transform>();
        _navMesh = GetComponent<NavMeshAgent>();
        _transformGun = transform.GetChild(1);    
        _GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
        }
    }

    private void RotateToTarget()
    {
        if (Vector3.Distance(transform.position, Target.position) < MinDistance && Target!=null)
        {
            Vector3 vect = Target.position - transform.position;
            Quaternion quaternion = Quaternion.LookRotation(vect);
            transform.rotation = quaternion;
            _timer += Time.deltaTime;
            if (_timer>0.5)
            {
                Instantiate(Bullet, _transformGun.position, _transformGun.rotation);
                _timer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.CompareTag("Bullet") && _GM != null)
            {
                TakeDamage(10);
                _GM.IncreaceScore();
            }
    }

    public void TakeDamage(int damage)
    {
        _helthEnemy -= damage;
        if (_helthEnemy == 100)
        {
            _flag = true;
        }
        if(_flag)
        {
            for (int i = 0; i < WayPoint.Length; i++)
            {
                Instantiate(EnemyBomb, WayPoint[i].position, Quaternion.identity);
            }
            _flag = false;
        }

        else if (_helthEnemy<=0)
        {
            _GM.EndOfGame(true);
            Destroy(gameObject);
        }
    }
}
