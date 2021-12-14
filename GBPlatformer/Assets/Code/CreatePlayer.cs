using UnityEngine;

namespace GBPlatformer
{
    public class CreatePlayer
    {
        private LevelObjectView playerPref;
        public CreatePlayer(LevelObjectView resourcesPlayerPrefab)
        {
            playerPref = resourcesPlayerPrefab;
        }

        public LevelObjectView PlayerMonoBeh()
        {
            return Object.Instantiate(playerPref, Vector3.zero, Quaternion.identity).GetComponent<LevelObjectView>();
        }
    }
}