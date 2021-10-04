using UnityEngine;

namespace AsteroidGB
{
    internal class CreatePlayer
    {
        private GameObject playerPref;
        public CreatePlayer(GameObject resourcesPlayerPrefab)
        {
            playerPref = resourcesPlayerPrefab;
        }

        public PlayerView PlayerMonoBeh()
        {
            return Object.Instantiate(playerPref, Vector3.zero, Quaternion.identity).GetComponent<PlayerView>();
        }
    }
}