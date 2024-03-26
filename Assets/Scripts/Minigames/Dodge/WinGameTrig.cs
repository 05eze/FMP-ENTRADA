using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameTrig : MonoBehaviour
{
    public GameObject winGame;
    private void Start()
    {
        winGame.SetActive(false);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("GameOver");
            Time.timeScale = 0f;
            winGame.SetActive(true);
        }
    }
}
