using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Bomb" || 
			target.tag == "Fruit" ||
			target.tag == "Poison" ||
			target.tag == "Freeze" ||
			target.tag == "Speed"
		) {
			target.gameObject.SetActive (false);
		}
	}

} // class
