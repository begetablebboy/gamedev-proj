using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownController : MonoBehaviour
{
    public int countdownTime;
    public bool done = false;
    public TextMeshProUGUI countdownDisplay;
    //[SerializeField]
    public GameObject[] initialObjects;

    private void Start()
    {
        foreach (GameObject go in initialObjects) go.SetActive(false);
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);

        foreach (GameObject go in initialObjects) go.SetActive(true);
        done = true;
        //initialObjects.SetActive(true);
    }
}
