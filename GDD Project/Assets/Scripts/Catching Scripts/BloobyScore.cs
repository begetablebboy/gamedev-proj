﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BloobyScore : MonoBehaviour {

	public Text scoreText;

	public GameObject gameCanvas;

	private int score = 0;

	// Use this for initialization
	void Awake () {
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		scoreText.text = "0";
	}

	void OnTriggerEnter2D (Collider2D target) {
	
		if (target.tag == "Bomb") {
			transform.position = new Vector2 (0, 100);
			target.gameObject.SetActive (false);
			EndGame();
		}

		if (target.tag == "Fruit") {
			
			score++;
			scoreText.text = score.ToString ();
		}

		if (target.tag == "Freeze") {
			target.gameObject.SetActive (false);
			if(gameObject.GetComponent<Player2Movement>()){
				gameObject.GetComponent<Player2Movement>().freeze();
			}
			else if(gameObject.GetComponent<PlayerMovement>()){
				gameObject.GetComponent<PlayerMovement>().freeze();
			}
		}

		if (target.tag == "Poison") {
			target.gameObject.SetActive (false);
			if(gameObject.GetComponent<Player2Movement>()){
				gameObject.GetComponent<Player2Movement>().poison();
			}
			else if(gameObject.GetComponent<PlayerMovement>()){
				gameObject.GetComponent<PlayerMovement>().poison();
			}
		}

		if (target.tag == "Speed") {
			target.gameObject.SetActive (false);
			if(gameObject.GetComponent<Player2Movement>()){
				gameObject.GetComponent<Player2Movement>().speedUp();
			}
			else if(gameObject.GetComponent<PlayerMovement>()){
				gameObject.GetComponent<PlayerMovement>().speedUp();
			}
		}

	}

	IEnumerator RestartGame() {
		yield return new WaitForSecondsRealtime (2f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	void EndGame() {
		Timer timer = gameCanvas.GetComponent<Timer>();
		PlayerPrefs.SetInt("Player2", PlayerPrefs.GetInt("Player2") + 1);
		timer.results.text = "Player 2 wins!";
		timer.EndGame();
		// timer.StartCoroutine(timer.ChangeGame());
		Application.LoadLevel("CatchingScore");
	}

} // class

































