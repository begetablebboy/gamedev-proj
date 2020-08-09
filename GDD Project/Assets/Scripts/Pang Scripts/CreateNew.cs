using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateNew :MonoBehaviour {
 public double time;
 public double usedTime=0;
[SerializeField]
 private GameObject XLball;
//  private GameObject XLball1; 

 
 
 void Start ()
 {

  XLball= GameObject.Find ("XL Ball");
  // XLball1= GameObject.Find ("XL Ball 1");

 }
 
 
 void Update ()
 {

  var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
  var time=Convert.ToInt64(ts.TotalSeconds);

  if(time%10==0 && time!=usedTime){
    
    Debug.Log("Yea");
    // StartCoroutine(Attack());
    Attack();
    usedTime=time;
    
  }
 }
 public void Attack()
 {
     Debug.Log("haha");
    // yield return new WaitForSeconds(1.0f);
     var clone1 = Instantiate (XLball);
    //  var clone2 = Instantiate (XLball1);
     
 }
}