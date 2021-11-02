using UnityEngine;

namespace MVVM_Game
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPosition;
        [SerializeField] private GameObject[] _gameObjects;
        private float timer;

        public void SpawnEnemy(float time)
        {
            timer += time;
            if (timer >3f)
            {
                var bonus = Instantiate(_gameObjects[Random.Range(0, _gameObjects.Length)],
                    _spawnPosition[Random.Range(0, _spawnPosition.Length)]);
                bonus.GetComponent<Rigidbody>().AddForce(Vector3.left * 3f, ForceMode.Impulse);
                timer = 0f;
            }
        }
    }
}