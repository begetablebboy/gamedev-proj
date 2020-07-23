using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour {

	private float speed = 10f;

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
        float h = Input.GetAxis("Horizontal");
        vel.x = h * speed;
		myBody.velocity = vel;

        if (canWalk)
        {
            // moving right
            if (h > 0)
            {

                Vector3 scale = transform.localScale; // get player current scale
                scale.x = 0.6f;
                transform.localScale = scale; // face the Right direction
                anim.SetBool("Walk", true);
            }
            //moving left
            else if (h < 0)
            {

                Vector3 scale = transform.localScale;
                scale.x = -0.6f;
                transform.localScale = scale; // face the Left direction
                anim.SetBool("Walk", true);
            }
            else if (h == 0)
            {
                anim.SetBool("Walk", false); //idle
            }

        }

    }


} // class


































