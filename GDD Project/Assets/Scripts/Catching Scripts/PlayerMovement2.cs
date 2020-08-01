using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement2 : MonoBehaviour {

	private float speed = 10f;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode rightKey;
    public KeyCode leftKey;

	private Rigidbody2D myBody;

    private Animator anim;
    private bool canWalk;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        canWalk = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 vel = myBody.velocity;
        float h1 = Input.GetAxis("Horizontal");
        vel.x = h1 * speed;
		myBody.velocity = vel;

        if (canWalk)
        {
            // moving right
            if (Input.GetKeyDown(rightKey))
            {

                Vector3 scale = transform.localScale; // get player current scale
                scale.x = 0.6f;
                transform.localScale = scale; // face the Right direction
                anim.SetBool("Walk", true);
            }
            //moving left
            else if (Input.GetKeyDown(leftKey))
            {

                Vector3 scale = transform.localScale;
                scale.x = -0.6f;
                transform.localScale = scale; // face the Left direction
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Walk", false); //idle
            }

        }

    }


} // class


































