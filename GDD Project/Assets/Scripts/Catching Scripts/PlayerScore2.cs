using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScore2 : MonoBehaviour {

	public Text scoreText2;

	private int score = 0;

	// Use this for initialization
	void Awake () {
		scoreText2 = GameObject.Find ("ScoreText2").GetComponent<Text> ();
		scoreText2.text = "0";
	}

	void OnTriggerEnter2D (Collider2D target) {
	
		if (target.tag == "Bomb") {
			transform.position = new Vector2 (0, 100);
			target.gameObject.SetActive (false);
			StartCoroutine (RestartGame());
		}

		if (target.tag == "Fruit") {
			target.gameObject.SetActive (false);
			score++;
			scoreText2.text = score.ToString ();
		}

	}

	IEnumerator RestartGame() {
		yield return new WaitForSecondsRealtime (2f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

} // class

































