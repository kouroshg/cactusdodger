using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpPower;
	public float runSpeed;
	public bool enableRun;
	private int jumpCount;
	private Animator animator;
	private Rigidbody2D rigidBody;
	private bool isReady;

	// Use this for initialization
	void OnEnable () {

		//Check if the neccessary components are assigned.
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();

		isReady = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(!isReady)
		{
			return;
		}

		// If the run flag is enabled run
		if(enableRun)
		{
			// Gradually increase speed otherwise set speed to 0.
			var toSpeed = enableRun ? runSpeed : 0;
			var toVector = new Vector2(toSpeed,rigidBody.velocity.y);
			rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, toVector, 0.1f);
			animator.SetFloat("Speed", rigidBody.velocity.x);
		}

		// Activate jump if single tap detected **(Double jumps allowed)**.
		if(IsTapping() && jumpCount < 2)
		{
			rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpPower);

			animator.ResetTrigger("Falling");
			animator.ResetTrigger("Landed");
			animator.SetTrigger("Jump");

			jumpCount++;
		}

		// Check if the player is falling
		if(rigidBody.velocity.y < 0)
		{
			if(transform.position.y > 0.001f)
			{
				// Falling
				animator.ResetTrigger("Landed");
				animator.ResetTrigger("Landed");
				animator.SetTrigger("Falling");
				
			} else {
				// Landing
				animator.ResetTrigger("Falling");
				animator.ResetTrigger("Jump");
				animator.SetTrigger("Landed");
				jumpCount = 0;
	
			}
		} 

	}

	bool IsTapping()
	{
		if (Input.touchCount > 0 )
        {
			//Track single touch only
            Touch touch = Input.GetTouch(0);

            // If the user is tapping the screen return true.
			if(touch.phase == TouchPhase.Began)
			{
				return true;
			}
        }

		return false;

	}
}
