using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyBomb;
    public bool Flag = true;
   
    private float _timer;
    private bool _count = false;
    private int i = 0;

    // private void CreateEnemyBomb()
    // {
    //     _timer += Time.deltaTime;
    //     if (Flag&&_timer>1f)
    //     {
    //         Instantiate(EnemyBomb, transform.position, transform.rotation);
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        i++;
        transform.GetComponent<BoxCollider>().center = new Vector3(0, 0, -3f);
        StartCoroutine("CreateBomb");
        if (i>=2)
        {
            StopCoroutine("CreateBomb");
            Destroy(gameObject);
        }
    }

    private IEnumerator CreateBomb()
    {

        while (Flag)
        {
            Instantiate(EnemyBomb, transform.position, transform.rotation);
            yield return new WaitForSeconds(3f);
        }


    }
}
