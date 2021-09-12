using System;
using System.Collections;
using UnityEngine;

namespace CodeGeek
{
    public delegate void EndTimer();
    
   public class TestCoroutine
   {
       public event EndTimer End;
        private Coroutine _coroutine;
        public void StartTestCoroutine(int i, ShowTimer timer)
        {
            if (_coroutine != null)
            {
                return;
            }
            _coroutine = Coroutines.StarRoutine(MyTimer(i, timer));
        }
        
        public void StopTestCoroutine()
        {
            Coroutines.StopRoutine(_coroutine);
            _coroutine = null;
        }
        
        private IEnumerator MyTimer(int i, ShowTimer timer)
        {
            while (i!=-1)
            {
                timer.Show(i);
                yield return new WaitForSeconds(1f);
                i--;
            }

            End?.Invoke();
        }
    }

    
}