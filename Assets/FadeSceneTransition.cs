using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeSceneTransition : MonoBehaviour
{
    //After pressing e, fade comes in and then transition occurs 

    public GameObject fadeTransition;

    // Start is called before the first frame update
    void Start()
    {
        fadeTransition.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {  
            StartCoroutine("StartTransition1");
        }
    }

    IEnumerator StartTransition1()
    {
        yield return new WaitForSeconds(4);
        fadeTransition.SetActive(true);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("2LandOfLiving");

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
