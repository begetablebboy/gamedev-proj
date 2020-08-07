using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    public GameObject ScoreContainer;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, speed); //move water further up the y-axis
    }

    void Update()
    {
        

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        // check if water collides with Top
        if (target.tag == "Top")
        {
            Destroy(gameObject);
        }

        string[] name = target.name.Split(); // get name of gameobject that the ball collides with
        // Why use Split?
        // e.g. string s = "XL Ball"; 
        // Split will seperate XL Ball into 'XL' and 'Ball', which can be utilised for different purposes
        // for (int i = 0; i < name.Length; i++)
        // {
           
              
        // if( name.Length > 1)
        // {
        //     if (name[1] == "Ball")
        //     {
        //          Debug.Log("water shot ball");// when water hit ball, water gets destroyed
                
        //     }


        // }
        // }
        
        if( name.Length > 1)
        {
            if (name[1] == "Ball")
            {
                Destroy(gameObject); // when water hit ball, water gets destroyed
                 ScoreContainer.GetComponent<scoreContainer>().UpdateScore1();
            }


        }
        
        
    }
}
