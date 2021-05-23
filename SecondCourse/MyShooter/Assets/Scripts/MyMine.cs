using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Explosive");
    }

    IEnumerator Explosive()
    {
        yield return new WaitForSeconds(3f);
        var collisions = Physics.OverlapSphere(transform.position, 3f);
        foreach (var ell in collisions)
        {
            if (ell.GetComponent<Rigidbody>()!=null && Vector3.Distance(transform.position,ell.transform.position)<3f)
            {
                ell.GetComponent<Rigidbody>().AddForce((ell.transform.position-transform.position)*200f);
                if (ell.GetComponent<ITakeDamage>() != null)
                {
                    ell.GetComponent<ITakeDamage>().TakeDamage(10);
                }
            }
        }
        Destroy(gameObject);
    }

}
