using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeGeek
{
    public class EleveatorUpDown : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            CheckPlayerOnElevator(other);
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.transform.parent = null;
            }
        }

        private void CheckPlayerOnElevator(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            collision.transform.SetParent(transform);
        }
    }
}

