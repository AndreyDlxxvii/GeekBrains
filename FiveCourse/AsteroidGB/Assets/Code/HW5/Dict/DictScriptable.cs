using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Новый словарь", menuName = "Данные/Словарь")]
public class DictScriptable : ScriptableObject
{
    [SerializeField] private List<string> keys = new List<string>();
    [SerializeField] private List<int> value = new List<int>();

    public List<string> Keys
    {
        get => keys;
        set => keys = value;
    }

    public List<int> Value
    {
        get => value;
        set => this.value = value;
    }
}
