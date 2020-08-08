using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        //mainListener.enabled = true;
        //mainSound.Play();
        Time.timeScale = 1f; // more than 1 will be faster, <1 slow motion
    }
}
