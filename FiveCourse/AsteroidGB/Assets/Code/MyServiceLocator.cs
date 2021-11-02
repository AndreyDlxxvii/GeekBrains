using System;
using System.Collections.Generic;

namespace AsteroidGB
{
    public static class MyServiceLocator
    {
        private static Dictionary<Type, object> myDict = new Dictionary<Type, object>();

        public static void SetLocator<T>(T myObject) where T : class
        {
            var keyValue = typeof(T);
            if (!myDict.ContainsKey(keyValue))
            {
                myDict[keyValue] = myObject;
            }
        }

        public static T GetLocator <T>()
        {
            var keyValue = typeof(T);
            if (myDict.ContainsKey(keyValue))
            {
                return (T) myDict[keyValue];
            }
            return default;
        }
    }
}