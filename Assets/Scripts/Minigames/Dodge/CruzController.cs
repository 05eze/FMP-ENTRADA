using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzController : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;

    private Rigidbody rb;
    
 
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * _velocity;
        }
    }
}
