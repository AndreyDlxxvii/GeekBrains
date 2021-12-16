using UnityEngine;

namespace MyRaces
{
    public static class ResourceLoader
    {
        public static GameObject LoadPrefab(ResourcesPath path)
        {
            var t = Resources.Load<GameObject>(path.PathResoursec);
            return t;
        }
    }
}