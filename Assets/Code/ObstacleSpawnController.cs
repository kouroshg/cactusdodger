using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnController : MonoBehaviour {

	public float minIntervalSec;
	public float maxIntervalSec;

	public GameObject[] obstacles;
	public Transform spawnPoint;

	private Rect screenRect;
	private float interval;
	
	// Update is called once per frame
	void Update () {

		// Spawn obstcles in random intervals
		 interval = interval - Time.deltaTime;
	
		if(interval < 0)
		{
			// Pick a random interval
			interval = Random.Range(minIntervalSec,maxIntervalSec);

			// Pick a random id for the obstacle array
			var rndId = Mathf.RoundToInt(Random.Range(0, obstacles.Length-1));
			var obstacle = Instantiate(obstacles[rndId], spawnPoint.position, Quaternion.identity).transform;
			var position = obstacle.localPosition;

			// Set the new obstacle as the child of this transform and scale to one.
			obstacle.SetParent(transform);
			obstacle.localScale = Vector3.one;
			obstacle.localPosition = new Vector3(position.x, position.y, 0);
		}
	}
}
