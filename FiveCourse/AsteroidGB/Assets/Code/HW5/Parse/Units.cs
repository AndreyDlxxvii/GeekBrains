using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Object = UnityEngine.Object;

namespace AsteroidGB.HW5.Parse
{
    [Serializable]
    public class Units
    {
        public Unit unit;

        public Units(Unit unit)
        {
            this.unit = unit;
        }
    }
}