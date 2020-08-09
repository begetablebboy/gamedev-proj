using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreContainer : MonoBehaviour
{
    // Start is called before the first frame update

    public Text Score1;
    public double score1 = 0;
    public Text Score2;
    public double score2 = 0;

    public TextMeshProUGUI result1;
    public TextMeshProUGUI result2;

    public TextMeshProUGUI drawResult;

    private string sceneName = "PangScore"; 

    public GameObject countdown;
    

    void Start()
    {

    Score1 = GameObject.Find ("P1 Score").GetComponent<Text> ();
    Score2 = GameObject.Find ("P2 Score").GetComponent<Text> ();
    PlayerPrefs.DeleteAll();
        
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
                    if (!PlayerPrefs.HasKey("Player2")){
                        PlayerPrefs.SetInt("Player1", 0);
                        PlayerPrefs.SetInt("Player2", 1);
                    }
                    result1.gameObject.SetActive(true);
                    
                }
                else if (int.Parse(Score1.text) > int.Parse(Score2.text)){
                    if (!PlayerPrefs.HasKey("Player2")){
                        PlayerPrefs.SetInt("Player1", 1);
                        PlayerPrefs.SetInt("Player2", 0);
                    }
                    result2.gameObject.SetActive(true);
                    
                }
                else {
                    if (!PlayerPrefs.HasKey("Player2")){
                        PlayerPrefs.SetInt("Player1", 1);
                        PlayerPrefs.SetInt("Player2", 1);
                    }
                    drawResult.gameObject.SetActive(true);
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
