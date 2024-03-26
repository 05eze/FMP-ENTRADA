using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCountdownScript : MonoBehaviour
{
    public GameObject countDown;

    private void Start()
    {
        countDown.SetActive(true);
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3.5f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
