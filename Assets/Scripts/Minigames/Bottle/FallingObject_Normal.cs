using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject_Normal : MonoBehaviour
{
    [SerializeField] private float velocity = 3f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        rb.velocity = Vector3.down * velocity;
    }
}
