using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject PressE;

    private void Start()
    {
        gameObject.tag = "Player";
        PressE.SetActive(false);

        /*if(other.gameObject.tag == "Player")
        {
            TriggerDialogue();
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        PressE.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E) /*&& other.gameObject.tag == "Player"*/)
        {
            Debug.Log("Key Pressed");
            TriggerDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player is out of range");
        PressE.SetActive(false);
        DisableDialogue();
    }

    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
    
    public void DisableDialogue()
    {
        FindAnyObjectByType<DialogueManager>().EndDialogue();
    }
}
