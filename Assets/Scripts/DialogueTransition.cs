using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTransition : MonoBehaviour
{
    public GameObject transition;
    DialogueManager manager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("2LandofDead");
    }

}
