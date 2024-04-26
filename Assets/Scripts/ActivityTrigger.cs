using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityTrigger : MonoBehaviour
{
    public Animator animator_cam;
    public GameObject battleAndMinigameUI;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        animator_cam.SetBool("IsOpen", true);
        battleAndMinigameUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
    }


    private void OnTriggerExit(Collider other)
    {
        animator_cam.SetBool("IsOpen", false);
        battleAndMinigameUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
