using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{
	public float speed = 100f;
	public float jumpForce = 20f;

	private bool facingRight = true;
	private bool grounded = false;
	private bool enableJump = false;
	private Transform groundCheck;
	
	void Awake()
	{
		// setting up references
		groundCheck = transform.Find ("groundCheck");
	}
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 땅을 밟고 있는가?
		grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground"));
		//print ("?? grounded = " + grounded );
		if (Input.GetButtonDown ("Jump") && grounded)
		{
			print ("---- enableJump = true");
			enableJump = true;
		}
	}


	// Update is called once per frame
	void FixedUpdate ()
	{
		float dirX = Input.GetAxis("Horizontal");
		//if (dirX != 0)
		//	print ("Update : " +dirX);
		
		Vector2 movement = new Vector2 (dirX, 0);		
		GetComponent<Rigidbody2D>().velocity = movement * speed;
		//GetComponent<Rigidbody2D> ().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
		
		// 좌우 이동에 따른 Hero 방향변경
		if (dirX < 0 && facingRight)
			Flip ();
		else if (dirX > 0 && !facingRight)
			Flip ();
		//		if (dirX < 0 && facingRight )
		
		//			GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
		//		else if (dirX > 0)
		//			GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

		if (enableJump)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			print ("@@@@ enableJump = false");
			enableJump = false;
		}
	}
	
	void Flip()
	{
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
