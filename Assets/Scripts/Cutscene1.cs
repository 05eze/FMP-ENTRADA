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
    private bool IsOpen;

    // Start is called before the first frame update


    private void Start()
    {


        //FindAnyObjectByType<PlayerMovement>().enabled = false;



    }
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
       
        animator_cam.SetBool("IsOpen", true);
        IsOpen = true;
    }


    private void Update()
    {
       // if (animator_cam != null)
      //  {
            animator_cam.SetBool("IsOpen", false);
            MainCam.SetActive(true);
            CutsceneCam.SetActive(false);
     //  }

     
       
        
    }

   


    
}
