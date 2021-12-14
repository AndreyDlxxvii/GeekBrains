using UnityEngine;

namespace GBPlatformer
{
    [CreateAssetMenu(menuName = "Configs / QuesrStoryConfig", fileName = "QuestStoryCfg", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] quests;
        public QuestStoryType questStoryType;
    }

    public enum QuestStoryType
    {
         Common,
         Resetable
    }
}