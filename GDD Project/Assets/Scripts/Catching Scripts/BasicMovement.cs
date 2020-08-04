using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 10f;

	public Rigidbody2D myBody;

    public Animator anim;
    public bool canWalk;

    void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        canWalk = true;
	}

    public void freeze(){
        anim.SetBool("Poison", false);
        anim.SetBool("Frozen", true);
        speed = 0f;
        StartCoroutine (Unfreeze(2f));
    }

    public void speedUp(){
        anim.SetBool("Poison", false);
        speed = 30f;
        StartCoroutine (Unfreeze(5f));
    }

    public void poison(){
        speed = -10f;
        anim.SetBool("Poison", true);
        anim.SetBool("Frozen", false);
        StartCoroutine (Unfreeze(5f));
    }

    IEnumerator Unfreeze(float waitTime) {
		yield return new WaitForSecondsRealtime (waitTime);
        anim.SetBool("Poison", false);
        anim.SetBool("Frozen", false);
		speed = 10f;
	}

}
