using UnityEngine;

namespace GBPlatformer
{
    public interface IQuestModel
    {
        bool TryComplete (GameObject activator);
    }
}