using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuFlow : MonoBehaviour
{
    //public Animator cam;
    
    
    public GameObject beginGame, beginGameText;
    public GameObject buttons;
    public GameObject logo;
    public GameObject transition;


    //public GameObject optionsMenu;


    private void Start()
    {
        buttons.SetActive(false);
        transition.SetActive(false);
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        beginGameText.SetActive(false);
        yield return new WaitForSeconds(4);
        Cursor.lockState = CursorLockMode.None;
        beginGameText.SetActive(true);

    }

    public void StartGame()
    {
        beginGame.gameObject.SetActive(false);
        beginGameText.gameObject.SetActive(false);
        buttons.gameObject.SetActive(true);

        logo.gameObject.SetActive(false);
    }

    /*IEnumerator*/ public void BeginGame()
    {

        transition.SetActive(true);
        //yield return new WaitForSeconds(2);
        //SceneManager.LoadScene("LandOfLiving");
        //yield return null;
    
    }

    public void Transition()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void OptionMenu()
    {

    }

    public void PlayCredits()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
