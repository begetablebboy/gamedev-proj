using UnityEngine;
using System.Collections;
using System;

 
 public class Hidden : MonoBehaviour
 {

    public int countdownTime = 25; 
    public GameObject[] initialObjects;
    public GameObject[] startObjects;
     // Use this for initialization
     void Start ()
     {
         foreach (GameObject go in initialObjects)
         {
               go.gameObject.SetActive(false);
         }
          StartCoroutine(CountdownToStart());

 
     }
     
     // Update is called once per frame
     void Update ()
     {
//          foreach (Transform child in this.transform)
//          {
          
//             var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
//             var time=Convert.ToInt64(ts.TotalSeconds);

//               if(time%100==0){
//                 //    child.gameObject.SetActive(true);

//             }
//      }
}


  IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {

            yield return new WaitForSeconds(1f);

            countdownTime--;

            if( countdownTime == 10)
            {
                foreach (GameObject go in startObjects)
         {
               go.gameObject.SetActive(true);
         }

            }
        }

       // yield return new WaitForSeconds(1f);
        foreach (GameObject go in initialObjects){
             go.gameObject.SetActive(true);
        }

     
    
    }
 }