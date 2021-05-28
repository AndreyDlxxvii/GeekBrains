using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour, ITakeDamage
{
   
    public float Speed = 5f;
    public float MinDistance = 10f;
    public GameObject Bullet;
    public Transform [] WayPoint;
    public GameObject EnemyBomb;

    private OpenSecondDoor _secondDoor;
    private float _timer;
    private Transform _transformTower;
    private Transform _transformGun;
    private Transform Target;
    private NavMeshAgent _navMesh;
    private int _currentWayPoint;
    private int _helthEnemy = 200;
    private GameManager _GM;
    private bool _flag;
    private GameManager _gameManager;
    
    private void Awake()
    {
        //_secondDoor = GameObject.Find("SecondDoor").GetComponent<OpenSecondDoor>();
        _GM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Target = GameObject.FindWithTag("Heart").GetComponent<Transform>();
        _navMesh = GetComponent<NavMeshAgent>();
        _transformGun = transform.GetChild(1);    
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
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
            Quaternion quaternion = Quaternion.LookRotation(vect);
            transform.rotation = quaternion;
            //Vector3 newDict = Vector3.RotateTowards(transform.forward, vect, Speed * Time.deltaTime, 0f);
            //transform.rotation = Quaternion.LookRotation(newDict);
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
            if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10);
            _GM.IncreaceScore();
            //_secondDoor.Increase();
        }
    }

    public void TakeDamage(int damage)
    {
        _helthEnemy -= damage;
        print(_helthEnemy);
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
            _gameManager.EndOfGame(true);
            Destroy(gameObject);
        }
    }
}
