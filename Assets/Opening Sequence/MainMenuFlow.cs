using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFlow : MonoBehaviour
{
    //public Animator cam;
    public GameObject beginGame, beginGameText;
    public GameObject buttons;


    public void StartGame()
    {
        beginGame.gameObject.SetActive(false);
        beginGameText.gameObject.SetActive(false);
        buttons.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
