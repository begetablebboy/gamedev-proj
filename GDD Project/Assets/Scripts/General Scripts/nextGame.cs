﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextGame : MonoBehaviour
{
    public string sceneName;
    public void changeGame(string sceneName){
        Application.LoadLevel(sceneName);
    }
}
