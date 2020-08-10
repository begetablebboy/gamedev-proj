using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowWinner : MonoBehaviour
{
    public TextMeshProUGUI winText;
    public GameObject blobbyWin;
    public GameObject chickyWin;
    public GameObject bothWin;


    // Start is called before the first frame update
    void Start()
    {
        whoWin();
        //Debug.Log(PlayerPrefs.GetInt("Player1"));
        //Debug.Log(PlayerPrefs.GetInt("Player2"));
    }

    public void whoWin()
    {
        if(PlayerPrefs.GetInt("Player1") > PlayerPrefs.GetInt("Player2"))
        {
            winText.text = "P1 Wins!";
            blobbyWin.SetActive(true);
            chickyWin.SetActive(false);
            bothWin.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Player1") < PlayerPrefs.GetInt("Player2"))
        {
            winText.text = "P2 Wins!";
            chickyWin.SetActive(true);
            blobbyWin.SetActive(false);
            bothWin.SetActive(false);
        }
        else
        {
            winText.text = "Everyone is a winner!"; //draw situation
            bothWin.SetActive(true);
            blobbyWin.SetActive(false);
            chickyWin.SetActive(false);
        }
    }
}
