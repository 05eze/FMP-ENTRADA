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
    }

    private void OnTriggerStay(Collider other)
    {
        PressE.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == "Player" && PressE.activeInHierarchy)
        {
            Debug.Log("key pressed STYYYYLLL");
            TriggerDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player is out of range");
        PressE.SetActive(false);
        DisableDialogue();
    }





    /*private void Input.GetKeyDown(KeyCode.E)
    {
        TriggerDialogue()
    }
    */
    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
    
    public void DisableDialogue()
    {
        FindAnyObjectByType<DialogueManager>().EndDialogue();
    }
}
