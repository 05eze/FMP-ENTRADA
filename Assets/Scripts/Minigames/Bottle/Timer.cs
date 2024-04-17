using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject wonGameScreen;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            Debug.Log("Game Won");
            remainingTime = 0;
            Time.timeScale = 0f;
            wonGameScreen.SetActive(true);

        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }




}
