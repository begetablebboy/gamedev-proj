﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    // Movement keys (customizable in Inspector)
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

    // Movement Speed
    public float speed = 16;

    // Wall Prefab
    public GameObject wallPrefab;

    // Current Wall
    Collider2D wall;

    // Last Wall's End
    Vector2 lastWallEnd;

    bool end = false;

    bool player1 = false;

    bool player2 = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        spawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for key presses
        if (Input.GetKeyDown(upKey))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
            spawnWall();
        }
        else if (Input.GetKeyDown(downKey))
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
            spawnWall();
        }
        else if (Input.GetKeyDown(rightKey))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            spawnWall();
        }
        else if (Input.GetKeyDown(leftKey))
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
            spawnWall();
        }

        fitColliderBetween(wall, lastWallEnd, transform.position);
    }

    void spawnWall()
    {
        // Save last wall's position
        lastWallEnd = transform.position;
        // Spawn a new Lightwall
        GameObject g = Instantiate(wallPrefab, transform.position, Quaternion.identity);
        wall = g.GetComponent<Collider2D>();
    }

    void fitColliderBetween(Collider2D co, Vector2 a, Vector2 b)
    {
        // Calculate the Center Position
        co.transform.position = a + (b - a) * 0.5f;

        // Scale it (horizontally or vertically)
        float dist = Vector2.Distance(a, b);
        if (a.x != b.x)
            co.transform.localScale = new Vector2(dist + 1, 1);
        else
            co.transform.localScale = new Vector2(1, dist + 1);
    }

    void OnTriggerEnter2D(Collider2D co)
    {
        // Not the current wall?
        if (co != wall)
        {
            // print("Player lost: " + name);
            // Destroy(gameObject);
            Debug.Log(gameObject.name);
            GameObject.Find("player_cyan").GetComponent<Rigidbody2D>().velocity = new Vector2();
            GameObject.Find("player_pink").GetComponent<Rigidbody2D>().velocity = new Vector2();
            if (co.gameObject.tag == "pinkwall" && gameObject.name == "player_cyan")
            {
                player1 = true;
            }
            else if (co.gameObject.tag == "bluewall" && gameObject.name == "player_pink")
            {
                player2 = true;
            }
            else if (co.gameObject.tag == "pinkwall" && gameObject.name == "player_pink")
            {
                player2 = true;
            }
            else if (co.gameObject.tag == "bluewall" && gameObject.name == "player_cyan")
            {
                player1 = true;
            }
            end = true;
        }
    }

    void OnGUI() // this will bring up your game won GUI when atEnd is true
    {
        if (end) //checks the value of the "atEend" variable and executes the code within if evaluated as true
        {
            GUI.BeginGroup(new Rect((Screen.width / 2) - 50, (Screen.height / 2) - 60, 100, 120)); // this begins a GUI group not required but it helps in organization
            if (player1)
            {
                //Debug.Log("Player Pink wins");
                GUI.Label(new Rect(0, 0, 100, 20), "Player 1 Win !!"); // this will display the "You Win" text
            }
            else if (player2)
            {
                //Debug.Log("Player Blue wins");
                GUI.Label(new Rect(0, 0, 100, 20), "Player 2 Win !!"); // this will display the "You Win" text
            }
            //GUI.Label(new Rect(0, 0, 100, 20), "You Win !!"); // this will display the "You Win" text
            if (GUI.Button(new Rect(0, 20, 100, 50), "Play Again")) // this displays the "play again" text and when clicked runs the "MoveToStart" function(method)
            {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            if (GUI.Button(new Rect(0, 70, 100, 50), "Quit")) // shows "quit" text and ends the game
            {
                Application.Quit();
            }
            GUI.EndGroup(); // this is required once to close the group started above
        }
    }
}
