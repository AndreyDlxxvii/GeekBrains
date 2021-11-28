using System;
using UnityEngine;

namespace GBPlatformer
{
    [Serializable]
    public struct EnemyConfig
    {
        public float Speed;
        public Transform[] WayPoints;
        public float MinTargetDist;
    }
}