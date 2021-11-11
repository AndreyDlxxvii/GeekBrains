using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemFata", menuName = "Tutorial/item")]
public class TestScriptable : ScriptableObject
{
    public string Name = "item";
    [SerializeField] private GameObject _prefab;

    public GameObject Prefab => _prefab;
}
