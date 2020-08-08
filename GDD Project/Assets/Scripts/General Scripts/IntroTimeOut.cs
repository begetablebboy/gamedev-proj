using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTimeOut : MonoBehaviour
{
    public GameObject IntroPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowIntro());
    }

    IEnumerator ShowIntro()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);

        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        if (IntroPanel != null)
        {
            bool isActive = IntroPanel.activeSelf;
            IntroPanel.SetActive(!isActive);
        }
    }
}
