using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCutscene : MonoBehaviour
{
    public GameObject CutsceneCamera;
    public GameObject PlayerCamera;



    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(RemoveCutscene());
        Debug.Log("Removing Cutscene");
    }

    // Update is called once per frame
    IEnumerator RemoveCutscene()
    {

        Debug.Log("Countdown begins");
        yield return new WaitForSeconds(14);
        CutsceneCamera.SetActive(false);
        PlayerCamera.SetActive(true);
    }
}
