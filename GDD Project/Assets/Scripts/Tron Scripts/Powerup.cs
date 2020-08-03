using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private GameObject[] power;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnPowerUp(1f));
    }

    IEnumerator SpawnPowerUp(float time) {
		yield return new WaitForSecondsRealtime (time);

		Vector3 temp = transform.position;
		temp.x = Random.Range (-60f, 60f);
        temp.y = Random.Range (-60f, 60f);

		Instantiate (power[Random.Range(0, power.Length)], temp, Quaternion.identity);

		StartCoroutine (SpawnPowerUp(Random.Range(10f, 15f)));

	}
}
