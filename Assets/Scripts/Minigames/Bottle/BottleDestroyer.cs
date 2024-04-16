using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleDestroyer : MonoBehaviour
{
    
    
    void OnCollisionEnter(Collision collision)
    {
        //Box Collector 
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collected bottle");
            Destroy(gameObject);
        }
        //GroundDetector
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("-1 life");
            Destroy(gameObject);
            LivesCounter.health -= 1;
        }
    }

}
