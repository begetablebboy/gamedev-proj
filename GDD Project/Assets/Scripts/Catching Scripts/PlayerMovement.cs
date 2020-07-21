using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private float speed = 10f;

	private Rigidbody2D myBody;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 vel = myBody.velocity;
		vel.x = Input.GetAxis ("Horizontal") * speed;
		myBody.velocity = vel;
	}


} // class


































