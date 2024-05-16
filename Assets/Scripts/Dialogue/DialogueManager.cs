using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;
using UnityEngine.UI;
using UnityEditor.Presets;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator_dialogue;
    public Animator animator_cam;

    public GameObject transition;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();  
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void StartDialogue (Dialogue dialogue)
    {
        FindAnyObjectByType<PlayerMovement>().enabled = false;
        FindAnyObjectByType<TopDownController>().enabled = false;



        //FindAnyObjectByType<DialogueTrigger>().PressE.SetActive(false); && 


        Cursor.lockState = CursorLockMode.None;

        animator_dialogue.SetBool("IsOpen", true);
        animator_cam.SetBool("IsOpen", true);


        //Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;


        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
                return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));   

    }


    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }



    public void EndDialogue()
    {
        FindAnyObjectByType<PlayerMovement>().enabled = true;
        FindAnyObjectByType<TopDownController>().enabled = true;

        //FindAnyObjectByType<DialogueTrigger>().PressE.SetActive(true);
        Debug.Log("End of conversation.");

        animator_dialogue.SetBool("IsOpen", false);
        animator_cam.SetBool("IsOpen", false);

        Cursor.lockState = CursorLockMode.Locked;

        transition.SetActive(true);
    }


}
