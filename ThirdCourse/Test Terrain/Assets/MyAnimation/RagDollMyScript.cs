using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class RagDollMyScript : MonoBehaviour
{

    [SerializeField] private Rigidbody[] RBS;
    [SerializeField] private Collider[] Colls;
    [SerializeField] private Rigidbody RB;

    [SerializeField] private float _killForce = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private AICharacterControl _script;
    void Start()
    {
        _animator = GetComponent<Animator>();
        RBS = GetComponentsInChildren<Rigidbody>();
        Colls = GetComponentsInChildren<Collider>();
        _navMesh = GetComponent<NavMeshAgent>();
        _script = GetComponent<AICharacterControl>();
        Revive();    
    }

    void SetRagdoll(bool active)
    {
        for (int i = 0; i < RBS.Length; i++)
        {
            RBS[i].isKinematic = !active;
            if (active)
            {
                RBS[i].AddForce(Vector3.forward*_killForce, ForceMode.Impulse);
            }
        }

        for (int i = 0; i < Colls.Length; i++)
        {
            Colls[i].enabled = active;
        }

        _script.enabled = active;
    }

    void SetMain(bool active)
    {
        _animator.enabled = active;
        _navMesh.enabled = active;
        RBS[0].isKinematic = !active;
        Colls[0].enabled = active;
        _script.enabled = active;
    }

    private void Kill()
    {
        SetRagdoll(true);
        SetMain(false);
    }

    private void Revive()
    {
        SetRagdoll(false);
        SetMain(true);
        Colls[1].enabled = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Kill();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Revive();
        }
    }
}
