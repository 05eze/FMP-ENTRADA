using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;


public class Deactivate : MonoBehaviour
{
    public GameObject ToDelete, ToDelete2, ToDelete3;
 
   
    private void OnTriggerEnter(Collider other)
    {
        ToDelete.gameObject.SetActive(false);
        ToDelete2.gameObject.SetActive(false);
        ToDelete3.gameObject.SetActive(false);
        
    }
}
