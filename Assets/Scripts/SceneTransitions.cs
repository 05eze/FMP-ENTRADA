using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public DialogueTrigger dialogue;
    //LAND OF LIVING TO LAND OF DEAD TRANSITIONS 
    public void LandOfLiving()
    {
        SceneManager.LoadScene("LandOfLiving");
    }

    /*public void LandOfLivingPart2()
    {
        FindAnyObjectByType<DialogueTrigger>().DisableDialogue();
        
        if (){

        }
    }*/

    public void LandOfDead()
    {
        SceneManager.LoadScene("LandOfDead");
    }


    //CRUZ MINIGAME TRANSITIONS
    public void RetryGame_Cruz()
    {
        SceneManager.LoadScene("DodgeMinigame");
    }
    
    public void WinGame_Cruz()
    {
        SceneManager.LoadScene("");
    }


    


}
