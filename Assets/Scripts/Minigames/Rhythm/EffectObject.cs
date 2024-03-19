using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    //How long object shows up on screen
    public float lifetime = 1f;


    void Start()
    {
        
    }


    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
