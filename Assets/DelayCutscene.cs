using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCutscene : MonoBehaviour
{
    public GameObject CutsceneCamera;
    public GameObject PlayerCamera;


    public GameObject FadeTransition;

    public GameObject laManoSpeech;
    public GameObject santaMuerteSpeech;

    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(RemoveCutscene());
        StartCoroutine(RemoveFade());
        StartCoroutine(TextQueues());
        Debug.Log("Removing Cutscene");
    }

    // Update is called once per frame
    IEnumerator RemoveCutscene()
    {

        FindAnyObjectByType<PlayerMovement>().enabled = false;
        Debug.Log("Countdown begins");
        yield return new WaitForSeconds(14);
        CutsceneCamera.SetActive(false);
        PlayerCamera.SetActive(true);
        FindAnyObjectByType<PlayerMovement>().enabled = true;
    }

    IEnumerator RemoveFade()
    {
        yield return new WaitForSeconds(3);
        FadeTransition.SetActive(false);
    }

    IEnumerator TextQueues()
    {

        laManoSpeech.SetActive(true);
        yield return new WaitForSeconds(4);
        laManoSpeech.SetActive(false);
        yield return new WaitForSeconds(4);
        santaMuerteSpeech.SetActive(true);
        yield return new WaitForSeconds(5);
        santaMuerteSpeech.SetActive(false);
    }
}
