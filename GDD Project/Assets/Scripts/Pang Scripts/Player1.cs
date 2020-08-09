using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player1 : MonoBehaviour
{
    [SerializeField]
    public GameObject rocket;
    [SerializeField]
    public AudioClip shootSound;
    private float speed = 9f;
    private float maxVelocity = 4f; // control speed of player
    private Rigidbody2D rb;
    private Animator anim;
    private bool canShoot;
    private bool canWalk;
    public AudioClip dieSound;
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthbar;
    private string sceneName = "CatchingScene"; 
    public AudioClip hitSound;
    public TextMeshProUGUI result1;

    void Awake()
    {
        InitializeVariables();
    }

    private void Start()
    {
        //healthcount = 3;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        result1.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    // FixedUpdate is called every couple(2-3) of frames
    void FixedUpdate()
    {
        PlayerWalk(); // call in FixedUpdate to prevent performance issue esp for heavy calculations
    }

    void Shoot()
    {
        if (Input.GetKeyDown("g"))
        {
            // when click left mouse button
            if (canShoot)
            {
                canShoot = false; // to not spam rockets
                StartCoroutine(ShootRocket());
            }
        }
    }

    IEnumerator ShootRocket()
    {
        canWalk = false; // stop walking when shooting
        anim.Play("BlobbyShoot_P"); //anim.Play("PangShoot");

        Vector3 temp = transform.position; // store the current position of the player, so the rocket can be shot wherever the player is
        temp.y = -1.9f; // where to shoot rocket upwards wrt player y-axis

        // instantiate gameobject rocket, position and rotation
        // TODO: Change to Object Pooling
        Instantiate(rocket, temp, Quaternion.identity);

        AudioSource.PlayClipAtPoint(shootSound, transform.position); // play shoot audio at player position

        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isShoot", false); // set isShoot condition in animator to false, so can go back from PangShoot back to PangIdle
        canWalk = true;
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
    }

    void InitializeVariables()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canShoot = true;
        canWalk = true;
    }

    void PlayerWalk()
    {
        var force = 0f;
        var velocity = Math.Abs(rb.velocity.x); // determine velocity of player (take absoulute value, always positive)
        float horizontal = Input.GetAxis("Horizontal2"); // return value of 0 to 1 if going Right, 0 to -1 if going Left

        // able to walk when not shoooting
        if (canWalk)
        {
            if (horizontal > 0)
            {
                // moving Right
                if (velocity < maxVelocity)
                {
                    force = speed;
                }

                // need to change the x-scale value to either 1 or -1 depending on which direction the player is moving
                Vector3 scale = transform.localScale; // get player current scale
                scale.x = 1;
                transform.localScale = scale; // face the Right direction

                anim.SetBool("isWalk", true); // simulate walk anim if true
            }
            else if (horizontal < 0)
            {
                // moving Left
                if (velocity < maxVelocity)
                {
                    force = -speed;
                }

                Vector3 scale = transform.localScale;
                scale.x = -1;
                transform.localScale = scale; // face the Left direction

                anim.SetBool("isWalk", true);
            }
            else if (horizontal == 0)
            {
                // not moving
                anim.SetBool("isWalk", false); //idle
            }

            rb.AddForce(new Vector2(force, 0)); // x = force (0f), y = 0 (player not moving along y-axis)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string[] name = collision.name.Split();
        
        if(name.Length > 1)
        {
            Debug.Log("name:" + name[0] + name[1]);

            if(name[1] == "Ball")
            {
                //healthcount = healthcount - 1;
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
                currentHealth = currentHealth - 1;
                healthbar.SetHealth(currentHealth);

                if (currentHealth == 0)
                {
                    anim.SetBool("isDie", true);
                    AudioSource.PlayClipAtPoint(dieSound, transform.position);
                    //when player touches ball, player dies
                    StartCoroutine(KillPlayer());
                }
            }
        }
    }

    IEnumerator KillPlayer()
    {
        transform.position = new Vector3(200, 200, 0); // move player out of the screen to indicate player die
        // restart game when player dies
        
        if (!PlayerPrefs.HasKey("Player2")){
            PlayerPrefs.SetInt("Player1", 0);
            PlayerPrefs.SetInt("Player2", 1);
        }
        
        result1.gameObject.SetActive(true);
       
        yield return new WaitForSeconds(1.5f); // wait for 1.5 secs after player dies, then restart level
                                               //Application.LoadLevel(Application.loadedLevelName);
        SceneManager.LoadScene(sceneName);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // win.Find ("winTextController").GetComponent<Text> ();
       

    }
}
