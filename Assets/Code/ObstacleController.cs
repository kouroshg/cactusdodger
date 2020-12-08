using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {


	public float destroyAfterSeconds;
	public Transform player;
	public int scoreValue;
	
	private bool scoreAdded;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(DestroyAfterSeconds());
	}
	
	// Update is called once per frame
	void Update () {

		// If we pass the obstacle we score!
		if(player.position.x > transform.position.x  && !scoreAdded)
		{
			//Add Score
			GameController.instance.AddScore(scoreValue);
			scoreAdded = true;
		}
	}

	IEnumerator DestroyAfterSeconds()
	{
		yield return new WaitForSeconds(destroyAfterSeconds);
		Destroy(gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		GameController.instance.GameOver();
	}
}
