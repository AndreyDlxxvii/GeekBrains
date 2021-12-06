using UnityEngine;

namespace GBPlatformer
{
    public class CoinQuestModel : IQuestModel
    {
        private const string _target = "Player";
        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(_target);
        }
    }
}