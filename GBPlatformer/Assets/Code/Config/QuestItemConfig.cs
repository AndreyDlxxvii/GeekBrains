using System.Collections.Generic;
using UnityEngine;

namespace GBPlatformer
{
    [CreateAssetMenu(menuName = "Configs / ItemConfig", fileName = "ItemCfg", order = 1)]
    public class QuestItemConfig : ScriptableObject
    {
        public int quesrId;
        public List<int> questItemCollection;
    }
}