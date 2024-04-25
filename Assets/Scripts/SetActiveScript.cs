using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SetActiveScript : MonoBehaviour
{
    public GameObject GameObject;
    
    private void Start()
    {
        GameObject.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.gameObject.SetActive(true);
       
    }





}
