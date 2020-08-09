using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCatching : MonoBehaviour
{
    public string sceneName = "Catching Intro";
    public void nextCatching (string sceneName){
        Application.LoadLevel(sceneName);
    }
}
