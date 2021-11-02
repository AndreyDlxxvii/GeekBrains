using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictScript : MonoBehaviour, ISerializationCallbackReceiver
{
    [SerializeField] private DictScriptable _dictScriptable;
    [SerializeField] private List<string> keys = new List<string>();
    [SerializeField] private List<int> value = new List<int>();

    private Dictionary<string, int> dict = new Dictionary<string, int>();

    public bool flagValue;
    
    public void OnBeforeSerialize()
    {
        if (flagValue)
        {
            keys.Clear();
            value.Clear();
            for (int i = 0; i < Math.Min(_dictScriptable.Keys.Count, _dictScriptable.Value.Count); i++)
            {
                keys.Add(_dictScriptable.Keys[i]);
                value.Add(_dictScriptable.Value[i]);
            }
        }
    }

    public void OnAfterDeserialize()
    {
    }
}

