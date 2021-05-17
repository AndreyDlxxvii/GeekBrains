using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusRespaw : MonoBehaviour
{ 

    public GameObject[] prefab;
    public float lifeRespawn;
    private int spawnIndexHeal, spawnIndexMine;
    
    void Start()
    {
    InvokeRepeating("BonusRespawn", 0, 1);
    }
    void BonusRespawn()
    {
        var spawnPoint = new Vector3(Random.Range(-10f, 10f), 4f, Random.Range(10f, 26f));
        spawnIndexMine = Random.Range(0, prefab.Length);
        GameObject bonus = Instantiate(prefab[spawnIndexMine], spawnPoint, Quaternion.identity);
        Destroy(bonus, lifeRespawn);

    }
}