using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    public LayerMask Mask;
    public AnimationCurve curve;
    
    [SerializeField] private Animator _animatorMy;
    [SerializeField] private Transform _handObj;
    [SerializeField] private Transform _lookObj;
    [SerializeField] private Transform _rightLowerLeg;
    [SerializeField] private Transform _rightFootT;
    
    [Range(0, 1)] [SerializeField] private float _rightHandWeight;
    [Range(0, 1)] [SerializeField] private float _leftHandWeight;

    [Range(0, 1)] [SerializeField] private float _rightFootWeight;

    private int _rightHash;
    private float _rightFoot;
    private Vector3 _rightFootPos;
    private Quaternion _rightFoorRot;
    private List <Collider> _listOfObjects = new List<Collider>();
    void Start()
    {
        _animatorMy = GetComponent<Animator>();
        _rightHash = Animator.StringToHash("right_foot");
        _rightLowerLeg = _animatorMy.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        _rightFootT = _animatorMy.GetBoneTransform(HumanBodyBones.RightFoot);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        //  _animatorMy.GetFloat(_rightHash);
        RaycastHit hit;
        
        if (Physics.Raycast(_rightLowerLeg.position, Vector3.down, out hit, 1f, Mask))
        {
            _rightFoot = 1;
            print(hit.collider.gameObject.name);
            Debug.DrawLine(_rightLowerLeg.position, Vector3.down);
            _rightFootPos = Vector3.Lerp(_rightFootT.position, hit.point + Vector3.up*0.3f, Time.deltaTime * 10f);
            _rightFoorRot = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        else
        {
            _rightFoot = 0;
        }
        _animatorMy.SetIKPositionWeight(AvatarIKGoal.RightFoot, _rightFoot);
        _animatorMy.SetIKRotationWeight(AvatarIKGoal.RightFoot, _rightFoot);
        
        _animatorMy.SetIKPosition(AvatarIKGoal.RightFoot, _rightFootPos);
        _animatorMy.SetIKRotation(AvatarIKGoal.RightFoot, _rightFoorRot);
        
        
        
        NewMethod(AvatarIKGoal.RightHand, _rightHandWeight);
        NewMethod(AvatarIKGoal.LeftHand, _leftHandWeight);
        
        if (_lookObj!=null)
        {
            _animatorMy.SetLookAtWeight(1);
            _animatorMy.SetLookAtPosition(_lookObj.position);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        float distance;
        if (!other.CompareTag("Ground"))
        {
            _listOfObjects.Add(other);
        }
    }

    private void Update()
    {
        ObjectForLook();
    }

    private void ObjectForLook()
    {
        foreach (var value in _listOfObjects)
        {
            var i = Vector3.Distance(transform.position + Vector3.up * 1.5f, value.gameObject.transform.position);
            if (i<2f)
            {
                _lookObj = value.transform;
            }
            else
            {
                _lookObj = null;
            }
        }
    }

    private void NewMethod(AvatarIKGoal Hand, float weight)
    {
        _animatorMy.SetIKPositionWeight(Hand, weight);
        _animatorMy.SetIKRotationWeight(Hand, weight);

        _animatorMy.SetIKPosition(Hand, _handObj.position);
        _animatorMy.SetIKRotation(Hand, _handObj.rotation);
    }
}
