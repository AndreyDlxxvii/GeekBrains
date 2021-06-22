using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MySkript : MonoBehaviour
{
    private NavMeshAgent _navMesh;
    public Transform [] WayPoint;
    private Animator _animator;

    private void Awake()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WalkOnWayPoint();
    }
    
    private void WalkOnWayPoint()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetBool("Walk", true);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", false);
            _navMesh.speed = 1f;
            if (_navMesh.remainingDistance<_navMesh.stoppingDistance)
            {
                _navMesh.SetDestination(WayPoint[Random.Range(0, WayPoint.Length)].position);
                
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("Run", true);
            _animator.SetBool("Walk", false);
            _animator.SetBool("Idle", false);
            _navMesh.speed = 2f;
            if (_navMesh.remainingDistance<_navMesh.stoppingDistance)
            {
                _navMesh.SetDestination(WayPoint[Random.Range(0, WayPoint.Length)].position);
                
            }
        }
        else
        {
            _animator.SetBool("Walk", false);
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", true);
            _navMesh.SetDestination(transform.position);
        }
    }
}
