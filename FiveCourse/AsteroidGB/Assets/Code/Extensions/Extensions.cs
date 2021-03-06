using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Random = System.Random;

namespace AsteroidGB
{
    public static partial class Extensions
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
        
        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
        
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Type must be iserializable");
            }
            if (ReferenceEquals(self, null))
            {
                return default;
            }

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static string NumReduction(this long num)
        {
            Dictionary<int, string> _dictionary = new Dictionary<int, string>
            {
                {0, ""},
                {1, "K"},
                {2, "M"},
                {3, "B"},
                {4, "T"}
            };
            
            int _count = 0;
            string number;
            var value = num;
            while (value >=1000)
            {
                _count++;
                value /=1000L;
            }
            number = $"{value}{_dictionary[_count]}";
            _count = 0;

            return number;
        }
    }
}