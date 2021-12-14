using UnityEngine;

namespace GBPlatformer
{
    public static class NextWayPoint
    {
        private static Transform currentWayPoint;
        private static int _count;

        public static Transform NextPoint(Transform[] _waypoints)
        {
            _count = (_count + 1) % _waypoints.Length;
            currentWayPoint = _waypoints[_count];
            return currentWayPoint;
        }
    }
}