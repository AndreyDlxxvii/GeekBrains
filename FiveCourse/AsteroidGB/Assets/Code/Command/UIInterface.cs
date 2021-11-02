using UnityEngine;

namespace AsteroidGB
{
    public abstract class UIInterface : MonoBehaviour
    {
        public abstract void Execute();
        public abstract void Cancel();
    }
}