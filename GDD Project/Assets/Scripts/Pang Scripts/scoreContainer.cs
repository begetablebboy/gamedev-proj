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
    

    void Start()
    {

    Score1 = GameObject.Find ("Score1").GetComponent<Text> ();
    Score2 = GameObject.Find ("Score2").GetComponent<Text> ();
        
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
}
