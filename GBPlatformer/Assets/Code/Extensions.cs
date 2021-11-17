using UnityEngine;

namespace GBPlatformer
{
    public static class Extensions
    {
        public static bool HasMethod(this object objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName) != null;
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
        
        public static Vector3 Change(this Vector3 org, object x = null, object y = null, object z = null)
        {
            return new Vector3(x == null ? org.x: (float)x, y == null ? org.y: (float)y, z == null ? org.z: (float)z);
        }

        public static bool LowerThanYPos(this Transform transformObject, float yCoordinate)
        {
            return (transformObject.position.y <= yCoordinate);
        }

    }
}