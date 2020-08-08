using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour {

	[SerializeField]
	private GameObject[] fruits;

	private BoxCollider2D col;

	float x1, x2;

	// Use this for initialization
	void Awake () {
		col = GetComponent<BoxCollider2D> ();

		x1 = transform.position.x - col.bounds.size.x / 2f;
		x2 = transform.position.x + col.bounds.size.x / 2f;

	}

	void Start () {
		StartCoroutine (SpawnFruit(1.0f));
	}

	IEnumerator SpawnFruit(float time) {
		yield return new WaitForSecondsRealtime (time);

		Vector3 temp1 = transform.position;
		temp1.x = Random.Range (x1, x2);
		Vector3 temp2 = transform.position;
		temp2.x = Random.Range (x1, x2);
		temp2.y += 3;

		Instantiate (fruits[Random.Range(0, fruits.Length)], temp1, Quaternion.identity);
		Instantiate (fruits[Random.Range(0, fruits.Length)], temp2, Quaternion.identity);

		StartCoroutine (SpawnFruit(Random.Range(1f, 2f)));

	}

} // class











































