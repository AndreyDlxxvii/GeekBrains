using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjects : MonoBehaviour
{
   [SerializeField] List<TestScriptable> StartItems = new List<TestScriptable>();
   public List<TestScriptable> secondList = new List<TestScriptable>();
   

   private void Start()
   {
      for (int i = 0; i < StartItems.Count; i++)
      {
         AddItem(StartItems[i]);
      }

      var t = Instantiate(secondList[0].Prefab);
   }

   private void AddItem(TestScriptable ell)
   {
      secondList.Add(ell);
   }
}
