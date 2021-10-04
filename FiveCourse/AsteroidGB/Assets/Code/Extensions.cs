using System;
using UnityEngine;
using Random = System.Random;

namespace AsteroidGB
{
    public static class Extensions
    {
        public static bool HasMethod(this object objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName) != null;
        }

        public static Enum Random(this Enum q)
        {
            var rnd = new Random();
            return (Enemys) rnd.Next(Enum.GetNames(typeof(Enemys)).Length);
        }
    }
}