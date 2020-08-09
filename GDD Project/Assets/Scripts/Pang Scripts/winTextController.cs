using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class winTextController : MonoBehaviour
{

    public TextMeshProUGUI winDisplay;
    // Start is called before the first frame update
    void Start()
    {
        winDisplay.gameObject.SetActive(false);
    }

    // Update is called once per frame


    public void player1Win(){
        StartCoroutine(UpdatePlayer1WinText());

    }

    public void player2Win(){
        StartCoroutine(UpdatePlayer2WinText());
    }
    
    IEnumerator UpdatePlayer1WinText()
    {
     winDisplay.gameObject.SetActive(true);
     winDisplay.text = "Player 1 Win!";   
       yield return new WaitForSeconds(3f); 
    }

     IEnumerator UpdatePlayer2WinText()
    {
     winDisplay.gameObject.SetActive(true);
     winDisplay.text = "Player 2 Win!";    
       yield return new WaitForSeconds(3f);
    }


}