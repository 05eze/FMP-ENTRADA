using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTransition : MonoBehaviour
{
    public GameObject Transition;

    private void OnTriggerEnter(Collider other)
    {
        Transition.SetActive(true);
        TriggerTransition();
    }



    IEnumerator TriggerTransition()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("LandOfDead");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
