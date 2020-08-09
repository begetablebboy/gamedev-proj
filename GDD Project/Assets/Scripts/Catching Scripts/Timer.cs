using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 1;
    public bool timerIsRunning = false;

    public Text results;
    public Text timeText;
    public Text player1Score;
    public Text player2Score;

    public GameObject player1;
    
    public GameObject player2;
    private string sceneName = "TronScene";
    private float timer = 0;
    private bool timerReached = false;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        results.text = "";
        Debug.Log(PlayerPrefs.GetString("PangWinner"));
    }

    void Update()
    {

        DisplayTime(timeRemaining);
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                if (int.Parse(player2Score.text) > int.Parse(player1Score.text)){
                    PlayerPrefs.SetString("CatchingWinner", "Player2");
                    results.text = "Player 2 wins!";
                    
                }
                else if (int.Parse(player1Score.text) > int.Parse(player2Score.text)){
                    PlayerPrefs.SetString("CatchingWinner", "Player1");
                    results.text = "Player 1 wins!";
                    
                }
                else {
                    PlayerPrefs.SetString("CatchingWinner", "Draw");
                    results.text = "Draw!";
                    
                    // Application.LoadLevel(sceneName);
                }
                EndGame();
                StartCoroutine (ChangeGame());
            }
        }
    }

    public void EndGame(){
        Destroy(player1.GetComponent<BloobyScore>());
        Destroy(player2.GetComponent<ChickyScore>());
        timeRemaining = 0;
        timerIsRunning = false;
    }

    public IEnumerator ChangeGame(){
        yield return new WaitForSecondsRealtime (5f);
		Application.LoadLevel(sceneName);
    }

    void DisplayTime(float timeToDisplay)
    {
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);

    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}