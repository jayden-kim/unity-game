using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject moster;
	public float startWait = 5;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator SpawnWaves()
	{
		//yield return new WaitForSeconds (1);

		while (true)
		{
			GameObject hazard = moster;
			Vector3 spawnPosition = new Vector3 (Random.Range (-8, 7), -3, 1);
			Instantiate (hazard, spawnPosition, Quaternion.identity);

			yield return new WaitForSeconds (startWait);
		}
	}
}
