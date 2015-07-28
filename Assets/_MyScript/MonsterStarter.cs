using UnityEngine;
using System.Collections;

public class MonsterMover : MonoBehaviour
{
	public float speed = 1.0f;
	public enum MonsterMoveState
	{
		TURNUP,
		MOVE
	};
	private MonsterMoveState currentState = MonsterMoveState.TURNUP;
	// Use this for initialization

	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = new Vector2 (0, 2) * speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate ()
	{
		// check monster move state
		float dirX = Random.Range (-5, 5);
		Vector2 movement = new Vector2 (dirX, 0);	

		GetComponent<Rigidbody2D>().velocity = movement * speed;

		// move up
		if (currentState == MonsterMoveState.TURNUP)
			MoveUp ();
		else if (currentState == MonsterMoveState.MOVE)
			MoveHorizontalRandom ();
	}

	void MoveUp()
	{
	}

	void MoveHorizontalRandom ()
	{
	}
}
