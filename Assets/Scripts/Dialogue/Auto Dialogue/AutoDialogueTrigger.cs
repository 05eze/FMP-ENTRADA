using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        gameObject.tag = "Player";
       

        /*if(other.gameObject.tag == "Player")
        {
            TriggerDialogue();
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Key Pressed");
        TriggerDialogue();      
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player is out of range");
       
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
