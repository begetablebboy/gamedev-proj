using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreContainer : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Score1;
    public double score1 = 0;
    public Text Score2;
    public double score2 = 0;

    public Text results;

    private string sceneName = "CatchingScene"; 

    public GameObject countdown;
    

    void Start()
    {

    Score1 = GameObject.Find ("P1 Score").GetComponent<Text> ();
    Score2 = GameObject.Find ("P2 Score").GetComponent<Text> ();
    results.text = "";
        
    }

    void Update(){
         if(GameObject.FindGameObjectsWithTag("XL Ball").Length == 0 &&
            GameObject.FindGameObjectsWithTag("L Ball").Length == 0 &&
            GameObject.FindGameObjectsWithTag("M Ball").Length == 0 &&
            GameObject.FindGameObjectsWithTag("S Ball").Length == 0 &&
            GameObject.FindGameObjectsWithTag("XS Ball").Length == 0 &&
            countdown.GetComponent<CountDownController>().done 
         ) {
              if (int.Parse(Score2.text) > int.Parse(Score1.text)){
                    PlayerPrefs.SetString("PangWinner", "Player2");
                    results.text = "Player 2 wins!";
                    
                }
                else if (int.Parse(Score1.text) > int.Parse(Score2.text)){
                    PlayerPrefs.SetString("PangWinner", "Player1");
                    results.text = "Player 1 wins!";
                    
                }
                else {
                    PlayerPrefs.SetString("PangWinner", "Draw");
                    results.text = "Draw!";
                }
                StartCoroutine (ChangeGame());
          }
    }

    // Update is called once per frame
    public void UpdateScore1()
    {
         score1+=1;

         Score1.text = score1.ToString ();		 
        
    }

      public void UpdateScore2()
    {
         score2+=1;

         Score2.text = score2.ToString ();		 
        
    }

    public IEnumerator ChangeGame(){
        yield return new WaitForSecondsRealtime (5f);
		Application.LoadLevel(sceneName);
    }
}
