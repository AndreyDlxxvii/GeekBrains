using System;
using System.Collections;
using UnityEngine;

namespace AsteroidGB
{
    public delegate void EndTimer();
    
   public class TestCoroutine
   {
       public event EndTimer End;
        private Coroutine _coroutine;
        public void StartTestCoroutine(float second)
        {
            if (_coroutine != null)
            {
                return;
            }
            _coroutine = Coroutines.StarRoutine(MyTimer(second));
        }
        
        public void StopTestCoroutine()
        {
            Coroutines.StopRoutine(_coroutine);
            _coroutine = null;
        }
        
        private IEnumerator MyTimer(float second)
        {
            while (second>0)
            {
                yield return new WaitForSeconds(0.1f);
                second-=0.1f;
            }

            End?.Invoke();
        }
    }

    
}