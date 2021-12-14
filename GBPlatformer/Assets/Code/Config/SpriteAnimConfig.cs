using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{
    [CreateAssetMenu (fileName = "SpriteAnimCfg", menuName = "Configs / Animation cfg", order = 1)]
    public class SpriteAnimConfig : ScriptableObject
    {    
        [Serializable]
        public sealed class SpriteSequence
        {
            public AnimState Track;
            public float Speed;
            public List<Sprite> SPrites = new List<Sprite>();
        }
        
        public List<SpriteSequence> Sequences = new List<SpriteSequence>();
    }
}