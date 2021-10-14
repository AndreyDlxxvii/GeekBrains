using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using AsteroidGB.HW5.Parse;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;


namespace AsteroidGB.HW5.Parse
{
    [Serializable]
    public class Parse : MonoBehaviour
    {
        
        private const string _folderName = "/Code/HW5/Parse";
        private const string _fileName = "Parse.txt";
        private float health;
        private EnemyFactory _enemyFactory;
        void Start()
        {
            _enemyFactory = new EnemyFactory();
            var folder = Application.dataPath + _folderName;
            var path = Path.Combine(folder, _fileName);
            var t = File.ReadAllText(path);
            ArrUnit r = JsonUtility.FromJson<ArrUnit>(t);
            foreach (var ell in r.listUnit)
            {
                _enemyFactory.Create(ell);
            }
        
        }
    }
}

