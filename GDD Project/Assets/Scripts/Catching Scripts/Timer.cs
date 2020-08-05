using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    public Text results;
    public Text timeText;
    public Text player1Score;
    public Text player2Score;


    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
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
                    results.text = "Player 2 wins!";
                }
                else if (int.Parse(player1Score.text) > int.Parse(player2Score.text)){
                    results.text = "Player 1 wins!";
                }
                else {
                    results.text = "Draw!";
                }
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
    float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);

    timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}