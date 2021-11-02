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
        public void StartTestCoroutine(int second)
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
        
        private IEnumerator MyTimer(int second)
        {
            while (second!=-1)
            {
                yield return new WaitForSeconds(1f);
                second--;
            }

            End?.Invoke();
        }
    }

    
}