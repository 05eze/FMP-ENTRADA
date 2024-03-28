using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleDestroyer : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
