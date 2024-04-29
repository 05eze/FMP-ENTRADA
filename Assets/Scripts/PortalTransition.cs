using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTransition : MonoBehaviour
{
    public GameObject Transition;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        Transition.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("LandOfDead");
    } 
   
}
