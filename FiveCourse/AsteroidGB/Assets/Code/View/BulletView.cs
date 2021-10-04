using System;
using System.Runtime.CompilerServices;
using CodeGeek;
using UnityEngine;

namespace AsteroidGB
{
    public delegate void HitOnTarget ();
    public class BulletView : MonoBehaviour
    {
        public event HitOnTarget Hit;
        //private TestCoroutine _coroutine;

        // private void Start()
        // {
        //     _coroutine = new TestCoroutine();
        //     _coroutine.StartTestCoroutine(1);
        //     _coroutine.End += MyCleanUp;
        // }
        //
        // private void MyCleanUp()
        // {
        //     Hit?.Invoke();
        //     _coroutine.End -= MyCleanUp;
        //     _coroutine.StopTestCoroutine();
        // }

        private void OnTriggerEnter(Collider other)
        {
            Hit?.Invoke();
        }
    }
}