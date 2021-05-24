using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyBomb;
    public bool Flag = true;
   
    private float _timer;
    private int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            i++;
            transform.GetComponent<BoxCollider>().center = new Vector3(0, 0, -3f);
            StartCoroutine("CreateBomb");
        }
        
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
            yield return new WaitForSeconds(2f);
        }


    }
}
