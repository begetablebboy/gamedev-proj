using System.Collections;
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

    // Up/Down Movement Check
    private bool isdownKey;
    private bool isupKey;

    // Movement Speed
    public float speed = 16;

    // Wall Prefab
    public GameObject wallPrefab;

    // Current Wall
    Collider2D wall;

    // Last Wall's End
    Vector2 lastWallEnd;

    Vector2 lastVelocity;

    bool end = false;

    bool addedScore = false;

    bool player1 = false;

    bool player2 = false;
    public AudioClip freezeSound;
    // Start is called before the first frame update
    void Start()
    {
        isdownKey = false;
        isupKey = false;

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
            transform.localRotation = Quaternion.identity; // get current rotation
            transform.localRotation = Quaternion.Euler(0, 0, 0); // reset the rotation to default
            Vector3 scale = transform.localScale;
            scale.y = 5f;
            transform.localScale = scale;
            spawnWall();

            isupKey = true;
            isdownKey = false;
        }
        else if (Input.GetKeyDown(downKey))
        {
            GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
            transform.localRotation = Quaternion.identity;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Vector3 scale = transform.localScale;
            scale.y = -5f;
            transform.localScale = scale;
            spawnWall();

            isupKey = false;
            isdownKey = true;
        }
        else if (Input.GetKeyDown(rightKey))
        {
            if (isdownKey == true && isupKey == false)
            {
                transform.localRotation = Quaternion.identity; // get local rotation
                transform.localRotation = Quaternion.Euler(0, 0, 90); // change the facing direction to the left 
            }
            else if (isdownKey == false && isupKey == true)
            {
                transform.localRotation = Quaternion.identity;
                transform.localRotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                transform.localRotation = Quaternion.identity;
                transform.localRotation = Quaternion.Euler(0, 0, -90);
            }

            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            spawnWall();
        }
        else if (Input.GetKeyDown(leftKey))
        {
            if (isdownKey == true && isupKey == false)
            {
                transform.localRotation = Quaternion.identity; // get local rotation
                transform.localRotation = Quaternion.Euler(0, 0, -90); // change the facing direction to the left 
            }
            else if (isdownKey == false && isupKey == true)
            {
                transform.localRotation = Quaternion.identity;
                transform.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                transform.localRotation = Quaternion.identity;
                transform.localRotation = Quaternion.Euler(0, 0, 90);
            }

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
            if (co.gameObject.tag == "Freeze" && gameObject.name == "player_cyan")
            {
                co.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(freezeSound, transform.position);
                freeze();
            }
            else if (co.gameObject.tag == "Freeze" && gameObject.name == "player_pink")
            {
                co.gameObject.SetActive(false);
                AudioSource.PlayClipAtPoint(freezeSound, transform.position);
                freeze();
            }
            else if (co.gameObject.tag == "Speed" && gameObject.name == "player_pink")
            {
                co.gameObject.SetActive(false);
                speedUp();
            }
            else if (co.gameObject.tag == "Speed" && gameObject.name == "player_cyan")
            {
                co.gameObject.SetActive(false);
                speedUp();
            }
            else
            {
                Debug.Log(gameObject.name);
                GameObject.Find("player_cyan").GetComponent<Rigidbody2D>().velocity = new Vector2();
                GameObject.Find("player_pink").GetComponent<Rigidbody2D>().velocity = new Vector2();
                if (co.gameObject.tag == "pinkwall" && gameObject.name == "player_cyan")
                {
                    player2 = true;
                }
                else if (co.gameObject.tag == "bluewall" && gameObject.name == "player_pink")
                {
                    player1 = true;
                }
                else if (co.gameObject.tag == "pinkwall" && gameObject.name == "player_pink")
                {
                    player1 = true;
                }
                else if (co.gameObject.tag == "bluewall" && gameObject.name == "player_cyan")
                {
                    player2 = true;
                }
                else if (co.gameObject.tag == "Wall" && gameObject.name == "player_cyan")
                {
                    player2 = true;
                }
                else if (co.gameObject.tag == "Wall" && gameObject.name == "player_pink")
                {
                    player1 = true;
                }
                end = true;
            }

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
                if(!addedScore){
                    PlayerPrefs.SetInt("Player1", PlayerPrefs.GetInt("Player1") + 1);
                    addedScore = true;
                }
                GUI.Label(new Rect(0, 0, 100, 20), "Player 1 Win !!"); // this will display the "You Win" text
            }
            else if (player2)
            {
                //Debug.Log("Player Blue wins");
                if(!addedScore){
                    PlayerPrefs.SetInt("Player2", PlayerPrefs.GetInt("Player2") + 1);
                    addedScore = true;
                }
                GUI.Label(new Rect(0, 0, 100, 20), "Player 2 Win !!"); // this will display the "You Win" text
            }
            //GUI.Label(new Rect(0, 0, 100, 20), "You Win !!"); // this will display the "You Win" text
            if (GUI.Button(new Rect(0, 20, 100, 50), "Play Again")) // this displays the "play again" text and when clicked runs the "MoveToStart" function(method)
            {
                SceneManager.LoadScene("TronScene", LoadSceneMode.Single);
            }
            if (GUI.Button(new Rect(0, 70, 100, 50), "Quit")) // shows "quit" text and ends the game
            {
                Application.Quit();
            }
            GUI.EndGroup(); // this is required once to close the group started above
        }
    }
    public void freeze()
    {
        speed = 0f;
        lastVelocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * speed;
        StartCoroutine(Unfreeze(2f));
    }

    public void speedUp()
    {
        speed = 30f;
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * (2f);
        StartCoroutine(NormalSpeed(5f));
    }
    IEnumerator NormalSpeed(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        speed = 16f;
    }

    IEnumerator Unfreeze(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        speed = 16f;
        GetComponent<Rigidbody2D>().velocity = lastVelocity;
    }
}
