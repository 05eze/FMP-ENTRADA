using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
    public GameObject spawnee;
    //public GameObject spawnee2;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(spawnee, transform.position, transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("SpawnObejct");
        }
        
       /*
        Instantiate(spawnee2, transform.position, transform.rotation);
        if(stopSpawning)
        {
            CancelInvoke("SpawnObejct");
        }
       */
    }
}
