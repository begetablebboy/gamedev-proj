using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Text chickyScore;
    private Text blobbyScore;
    private double chick = 0;
    private double blob = 0;
    // public string sceneName;
    void Start()
    {
    chickyScore = GameObject.Find ("Chicky Score").GetComponent<Text> ();
    blobbyScore = GameObject.Find ("Blobby Score").GetComponent<Text> ();
     
    }

    // Update is called once per frame
    void Update()
    {
        blob = PlayerPrefs.GetInt("Player1");
        chick = PlayerPrefs.GetInt("Player2");

        chickyScore.text = chick.ToString ();
        blobbyScore.text = blob.ToString ();
        
        // StartCoroutine (ChangeGame());

    }

    // public IEnumerator ChangeGame(){
    //     yield return new WaitForSecondsRealtime (5f);
	// 	Application.LoadLevel(sceneName);
    // }
}
