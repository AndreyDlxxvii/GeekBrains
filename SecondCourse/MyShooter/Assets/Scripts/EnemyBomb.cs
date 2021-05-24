using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyBomb : MonoBehaviour
{
   
    public float MinDistance = 1f;
    public Transform [] WayPoint;

    private GameObject _target;
    private NavMeshAgent _navMesh;
    private int _currentWayPoint;
    
    private void Awake()
    {
       _target = GameObject.FindWithTag("Player");
       _navMesh = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _navMesh.SetDestination(WayPoint[0].position);
    }

    void Update()
    {
        WalkOnWayPoint();
    }

    private void WalkOnWayPoint()
    {
        var q = WayPoint.Length;
        if (_navMesh.remainingDistance < _navMesh.stoppingDistance)
        {
            _navMesh.SetDestination(WayPoint[Random.Range(0, WayPoint.Length)].position);
        }
        else if (Vector3.Distance(transform.position, _target.transform.position) < MinDistance)
        {
            _navMesh.SetDestination(_target.transform.position);
        }
    }

   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Player"))
        {
            _target.GetComponent<ITakeDamage>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
