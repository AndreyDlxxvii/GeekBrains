using System.Collections;
using System.Collections.Generic;
using GBPlatformer;
using UnityEngine;

public class DoorView : MonoBehaviour
{
    [SerializeField] private Transform[] _doorPlatform;

    public Transform[] DoorPlatform
    {
        get => _doorPlatform;
    }
}
