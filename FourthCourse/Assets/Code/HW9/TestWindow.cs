using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CodeGeek
{
    public class TestWindow : EditorWindow
    {
        public GameObject GameObject;
        public int CountOfObjects;

        private Vector2 _firstPoint;
        private Vector2 _secondPoint;
        private Vector2 _thirdPoint;
        private Queue<Transform> _spawnObjects = new Queue<Transform>();

        private bool _button;
        private bool _secondButton;
        private void OnGUI()
        {
            GUILayout.Label("Треугольник Серпинского", EditorStyles.boldLabel);
            GameObject = EditorGUILayout.ObjectField("Объект", GameObject, typeof(GameObject), true) as GameObject;
            _firstPoint = EditorGUILayout.Vector2Field("Позиция 1 точки", _firstPoint);
            _secondPoint = EditorGUILayout.Vector2Field("Позиция 2 точки", _secondPoint);
            _thirdPoint = EditorGUILayout.Vector2Field("Позиция 3 точки", _thirdPoint);
            _button = GUILayout.Button("Создать объекты");
            CountOfObjects = (int) EditorGUILayout.Slider("Количество объектов", CountOfObjects, 0, 10000);
            
            if (_spawnObjects.Count>0)
            {
                _secondButton = GUILayout.Button("Удалить объекты");
            }
            
            if (_button && GameObject)
            {
                int x = 0;
                int y = 0;
                
                for (int i = 0; i < CountOfObjects; i++)
                {
                    var e = Random.Range(0, 3);
                    switch (e)
                    {
                        case 0: x = (x + (int)_firstPoint.x) / 2; y = (y + (int)_firstPoint.y) / 2; break;
                        case 1: x = (x + (int)_secondPoint.x) / 2; y = (y + (int)_secondPoint.y) / 2; break;
                        default: x = (x + (int)_thirdPoint.x) / 2; y = (y + (int)_thirdPoint.y) / 2; break;
                    }
                    var temp = new Vector3(x,y,0);
                    var objGameObject = Instantiate(GameObject, temp, Quaternion.identity);
                    _spawnObjects.Enqueue(objGameObject.transform);
                }
            }

            if (_secondButton)
            {
                while (_spawnObjects.Count>0)
                {
                    DestroyImmediate(_spawnObjects.Dequeue().gameObject);
                }
                
            }
        }
    }
}