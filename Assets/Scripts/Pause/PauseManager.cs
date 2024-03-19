using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public KeyCode pauseKey;

    public static bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        AudioSource[] audio = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audio)
        {
            a.Pause();
        }

        Cursor.lockState = CursorLockMode.None;
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        AudioSource[] audio = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audio)
        {
            a.Play();
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
