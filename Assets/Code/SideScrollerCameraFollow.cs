using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerCameraFollow : MonoBehaviour {

	public Transform target;
	public float offestX;
	public float damp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Create a custom point to follow with adjustable offset so that player can be set a little off center.
		var targetPoint = new Vector3(target.position.x + offestX,transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPoint, Time.deltaTime * damp);
	}
}
