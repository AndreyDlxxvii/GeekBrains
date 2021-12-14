using UnityEngine;

namespace GBPlatformer
{
    [CreateAssetMenu(menuName = "Configs / QuestConfig", fileName = "QuestCfg", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType questType;
    }
    public enum QuestType
    {
        GetCoins,
    }
}