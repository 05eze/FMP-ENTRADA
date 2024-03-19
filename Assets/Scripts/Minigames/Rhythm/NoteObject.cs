using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject okEffect, goodEffect, perfectEffect, missEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.x) < 6.58f)
                {
                    GameManager.instance.NormalHit();
                    Instantiate(okEffect, transform.position, okEffect.transform.rotation);

                    //Instantiate means to bring in an object. 
                    //using the same rotation as prefab, so write ___Effect.transform.rotation

                } else if(Mathf.Abs(transform.position.x) < 6.75f)
                {
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                } else
                {
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;

        }
    }


    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
