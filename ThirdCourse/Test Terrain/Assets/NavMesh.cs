using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh : MonoBehaviour
{
    private NavMeshAgent _navMesh;
    [SerializeField] private Transform [] WayPoint;
   
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        WalkOnWayPoint();
    }
    
    private void WalkOnWayPoint()
    {
        if (_navMesh.remainingDistance<_navMesh.stoppingDistance)
        {
            _navMesh.SetDestination(WayPoint[Random.Range(0, WayPoint.Length)].position);
        }
    }

    
}
