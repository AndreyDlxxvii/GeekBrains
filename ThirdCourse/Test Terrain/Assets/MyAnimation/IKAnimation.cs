using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    public LayerMask Mask;
    
    [SerializeField] private Animator _animatorMy;
    [SerializeField] private Transform _handObj;
    [SerializeField] private Transform _lookObj;
    [SerializeField] private Transform _rightFoot;
    
    [Range(0, 1)] [SerializeField] private float _rightHandWeight;

    [Range(0, 1)] [SerializeField] private float _rightFootWeight;

    private int _rightHash;
    private Vector3 _rightFootPos;
    private Quaternion _rightFoorRot;
    void Start()
    {
        _animatorMy = GetComponent<Animator>();
        _rightHash = Animator.StringToHash("right_foot");
    }

    private void OnAnimatorIK(int layerIndex)
    {
        _animatorMy.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightHandWeight);
        _animatorMy.SetIKRotationWeight(AvatarIKGoal.RightHand, _rightHandWeight);
        if (_handObj)
        {
            _animatorMy.SetIKPosition(AvatarIKGoal.RightHand, _handObj.position);
            _animatorMy.SetIKRotation(AvatarIKGoal.RightHand, _handObj.rotation);
        }

        if (_lookObj)
        {
            _animatorMy.SetLookAtWeight(1);
            _animatorMy.SetLookAtPosition(_lookObj.position);
        }
    }
}
