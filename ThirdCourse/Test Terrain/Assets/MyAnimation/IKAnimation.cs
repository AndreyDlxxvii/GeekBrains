using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animatorMy;
    [SerializeField] private Transform _handObj;
    [SerializeField] private Transform _lookObj;

    [SerializeField] private float _rightHandWeight;
    void Start()
    {
        _animatorMy = GetComponent<Animator>();
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
