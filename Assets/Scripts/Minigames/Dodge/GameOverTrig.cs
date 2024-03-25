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
    void OnColliderEnter (Collider other)
    {
        if(tag == "Player")
        {
            Debug.Log("GameOver");
            gameOver.SetActive(true);
        }
    }
}
