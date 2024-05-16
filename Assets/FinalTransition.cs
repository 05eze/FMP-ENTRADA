using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTransition : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }
}
