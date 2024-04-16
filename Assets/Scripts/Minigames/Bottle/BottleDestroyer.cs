using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleDestroyer : MonoBehaviour
{
    
    
    void OnTriggerEnter(Collider other)
    {
        //Box Collector 
        if (gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        //GroundDetector
        {

        }
    }

}
