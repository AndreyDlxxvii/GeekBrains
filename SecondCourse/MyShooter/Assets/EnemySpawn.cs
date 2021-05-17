using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{


    public Transform[] spawnPoint;
    public GameObject[] prefab;
    public int CountOfEnemy;
    
    private int spawnIndexHeal, spawnIndexPrefab, spawnIndexPoint;
    
    void Start()
    {
        BonusRespawn();
    }
    void BonusRespawn()
    {
        //var spawnPoint = new Vector3(Random.Range(-10f, 10f), 4f, Random.Range(10f, 26f));
        for (int i = 0; i < CountOfEnemy; i++)
        {
            spawnIndexPrefab = Random.Range(0, prefab.Length);
            GameObject enemy = Instantiate(prefab[spawnIndexPrefab], spawnPoint[i]);
        }
        
        //GameObject bonus = Instantiate(prefab[spawnIndexPrefab], spawnPoint[spawnIndexPoint], Quaternion.identity)};
        //Destroy(bonus, lifeRespawn);

    }
}
