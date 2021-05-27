using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSpawn : MonoBehaviour
{
    public GameObject[] prefab;
    public float lifeRespawn;
    private int spawnIndexHeal, spawnIndexMine;
    public Transform[] SpawnPoint;
    
    void Start()
    {
        InvokeRepeating("BonusRespawn", 0, 3);
    }
    void BonusRespawn()
    {
        spawnIndexMine = Random.Range(0, prefab.Length);
        GameObject bonus = Instantiate(prefab[spawnIndexMine], SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, Quaternion.identity);
        Destroy(bonus, lifeRespawn);
    }
}
