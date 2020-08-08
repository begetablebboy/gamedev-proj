using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private float forceX, forceY;
    private Rigidbody2D rb;
    [SerializeField]
    private bool moveLeft;
    [SerializeField]
    private bool moveRight;
    [SerializeField]
    private GameObject originalBall; // XL ball
    private GameObject ball1, ball2; //split the ball into 2 smaller balls
    private Ball ball1Script, ball2Script; // need scripts for the smaller balls to manipulate their speed and direction
    [SerializeField]
    private AudioClip[] popSounds; // array bcos got 2 balls

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SetBallSpeed();
        // Score2.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
    }

    void InstantiateBalls()
    {
        if(this.gameObject.tag != "XS Ball")
        {

            // split the ball into 2 smaller balls
            ball1 = Instantiate(originalBall);
            ball2 = Instantiate(originalBall);

            ball1.name = originalBall.name; // this is to prevent having Ball(Clone) instead of Ball when Split in Rocket.cs
            ball2.name = originalBall.name;

            ball1Script = ball1.GetComponent<Ball>();
            ball2Script = ball2.GetComponent<Ball>();
        }
    }


    void InitializeBallandDisableCurrentBall()
    {
        InstantiateBalls();

        // get position of balls
        Vector3 temp = transform.position;

        ball1.transform.position = temp;
        ball1Script.SetMoveLeft(true);

        ball2.transform.position = temp;
        ball2Script.SetMoveRight(true);

        // give the ball some boost
        //ball1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2.5f);
        //ball2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2.5f);

        AudioSource.PlayClipAtPoint(popSounds[Random.Range(0, popSounds.Length)], transform.position); // play popSounds at position
        gameObject.SetActive(false);
    }

    public void SetMoveLeft(bool canMoveLeft)
    {   
        // this.ScoreContainer= ScoreContainer.GetComponent<ScoreContainer>();
        this.moveLeft = canMoveLeft;
        this.moveRight = !canMoveLeft; // if moveLeft is true, ! will make it false
    }

    public void SetMoveRight(bool canMoveRight)
    {
        // this.ScoreContainer= ScoreContainer.GetComponent<ScoreContainer>();
        this.moveRight = canMoveRight;
        this.moveLeft = !canMoveRight;
    }

    void MoveBall()
    {
        // TODO: Randomize where the ball is being spawned
        if (moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x -= forceX * Time.deltaTime; // move Left = negative
            transform.position = temp;
        }

        if (moveRight)
        {
            Vector3 temp = transform.position;
            temp.x += forceX * Time.deltaTime; // move Right = npositive
            transform.position = temp;
        }
    }

    void SetBallSpeed()
    {
        forceX = 2.5f; // same force for all balls

        // manipulate forceY for different sizes of balls to set ball speed
        switch (this.gameObject.tag)
        {
            case "XL Ball":
                //forceY = 11.5f;
                forceY = 11.5f;
                break;

            case "L Ball":
                //forceY = 10.5f;
                forceY = 11f;
                break;

            case "M Ball":
                //forceY = 9f;
                forceY = 10.5f;
                break;

            case "S Ball":
                //forceY = 8f;
                forceY = 10f;
                break;

            case "XS Ball":
                //forceY = 7f;
                forceY = 10f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // bounce ball
        // if ball touched the ground
        if (collision.tag == "Ground")
        {
            rb.velocity = new Vector2(0, forceY);
        }

        if (collision.tag == "Right Wall")
        {
            SetMoveLeft(true);
        }

        if (collision.tag == "Left Wall")
        {
            SetMoveRight(true);
        }

        if (collision.tag == "Water")
        {
            // ScoreContainer.GetComponent<scoreContainer>().UpdateScore();
               
            if(gameObject.tag != "XS Ball")
            {
                // if not XS ball, continue to instantiate new balls
                InitializeBallandDisableCurrentBall();             
            }
            else
            {
                AudioSource.PlayClipAtPoint(popSounds[Random.Range(0, popSounds.Length)], transform.position);
                gameObject.SetActive(false);
            }
           
        }

         if (collision.tag == "Plasma")
        {
            if(gameObject.tag != "XS Ball")
            {
                // if not XS ball, continue to instantiate new balls
                InitializeBallandDisableCurrentBall();              
            }
            else
            {
                AudioSource.PlayClipAtPoint(popSounds[Random.Range(0, popSounds.Length)], transform.position);
                gameObject.SetActive(false);
            }
        }   
        
    }
}
