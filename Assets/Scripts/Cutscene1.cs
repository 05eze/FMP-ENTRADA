using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1 : MonoBehaviour
{
    public GameObject laManoSpeech;
    public GameObject santaMuerteSpeech;
    public GameObject MainCam;
    public GameObject CutsceneCam;
    // Start is called before the first frame update


    private void Start()
    {
        
       
        FindAnyObjectByType<PlayerMovement>().enabled = false;
        StartCutscene();
        
    }
    // Update is called once per frame
    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(2);
        laManoSpeech.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        laManoSpeech.SetActive(false);
        yield return new WaitForSeconds(3);
        santaMuerteSpeech.SetActive(true);
        yield return new WaitForSeconds(5.4f);
        MainCam.SetActive(true);
        FindAnyObjectByType<PlayerMovement>().enabled = true;
    }
}
