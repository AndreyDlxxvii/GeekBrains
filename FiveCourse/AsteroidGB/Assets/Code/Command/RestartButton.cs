using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidGB;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AsteroidGB
{ 
    public class RestartButton : UIInterface
    {
        public override void Execute()
        {
            gameObject.SetActive(true);
            GetComponent<Button>().onClick.AddListener(Restart);
        }

        public override void Cancel()
        {
            gameObject.SetActive(false);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}


