using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CruzMinigameInteract : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BorrachoMinigame()
    {
        SceneManager.LoadScene("BottleMinigame");
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("In Radius");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key Pressed");
            BorrachoMinigame();
        }
    }
}
