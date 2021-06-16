using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUI1 : MonoBehaviour
{
    private float _fps;
    private int i=100;
    private void OnGUI()
    {
        GUIStyle _style = new GUIStyle(GUI.skin.window);
        _style.fontSize = 30;
        
        _fps = 1.0f / Time.deltaTime;
        GUILayout.Label("FPS: " + (int)_fps, _style);
        GUILayout.Label($"HP: " + i, _style);
    }
}
