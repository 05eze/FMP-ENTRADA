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


    //public GameObject optionsMenu;


    private void Start()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(4);

    }

    public void StartGame()
    {
        beginGame.gameObject.SetActive(false);
        beginGameText.gameObject.SetActive(false);
        buttons.gameObject.SetActive(true);

        logo.gameObject.SetActive(false);
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("LandOfLiving");
    
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
