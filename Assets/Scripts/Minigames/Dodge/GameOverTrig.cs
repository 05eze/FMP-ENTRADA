using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrig : MonoBehaviour
{

    public GameObject gameOver;
    private void Start()
    {
        gameOver.SetActive(false);
    }
    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("GameOver");
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
}
