using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBomb : MonoBehaviour
{
   
    //public float Speed = 5f;
    public float MinDistance = 2f;
    public GameObject Bullet;
    public Transform [] WayPoint;

    private OpenSecondDoor _secondDoor;
    private float _timer;
    private Transform _transformTower;
    private Transform _transformGun;
    private GameObject Target;
    private NavMeshAgent _navMesh;
    private int _currentWayPoint;
    
    private void Awake()
    {
        _secondDoor = GameObject.Find("SecondDoor").GetComponent<OpenSecondDoor>();
        Target = GameObject.FindWithTag("Player");
        _navMesh = GetComponent<NavMeshAgent>();
        // _transformGun = transform.GetChild(1);
    }

    private void Start()
    {
        _navMesh.SetDestination(WayPoint[0].position);
    }

    void Update()
    {
        //RotateToTarget();
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

        else if (Vector3.Distance(transform.position, Target.transform.position) < MinDistance)
        {
            _navMesh.SetDestination(Target.transform.position);
        }
    }

    // private void RotateToTarget()
    // {
    //     if (Vector3.Distance(transform.position, Target.position) < MinDistance )
    //     {
    //         Vector3 vect = Target.position - transform.position;
    //         Vector3 newDict = Vector3.RotateTowards(transform.forward, vect, Speed * Time.deltaTime, 0f);
    //         transform.rotation = Quaternion.LookRotation(newDict);
    //     }
    // }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            Target.GetComponent<Control1>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
