using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzController : MonoBehaviour
{
    public Rigidbody rb;
    //public float speed;
    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.right * 10f;
        rb.velocity = Vector3.down * 5f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight);
        }
    }
}
