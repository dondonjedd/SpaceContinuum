using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.Crash();
        }

        if (other.gameObject.CompareTag("Asteroid")) { 
            //TODO
        }

        return;
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
