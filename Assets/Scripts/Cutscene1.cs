using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene1 : MonoBehaviour
{
    public GameObject laManoSpeech;
    public GameObject santaMuerteSpeech;
    public GameObject MainCam;
    public GameObject CutsceneCam;

    public Animator animator_cam;
    

    // Start is called before the first frame update


    private void Start()
    {


        //FindAnyObjectByType<PlayerMovement>().enabled = false;



    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        PlayAnimation();
       
    }

    IEnumerator PlayAnimation()
    {
        animator_cam.SetBool("IsOpen", true);
        yield return new WaitForSeconds(1);
    }


    /*private void Update()
    {
            animator_cam.SetBool("IsOpen", false);
            MainCam.SetActive(true);
            CutsceneCam.SetActive(false);
    }*/

   


    
}
