using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTileController : MonoBehaviour {
	
	private Rect screenRect;

	// Use this for initialization
	void Awake () {
		screenRect = new Rect(0,0,Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		var firstBlock = transform.GetChild(0);
		var blockWidth = firstBlock.GetComponent<BoxCollider2D>().size.x;
		var rightAnchorPosition = new Vector3(firstBlock.transform.localPosition.x + blockWidth, firstBlock.localPosition.y);
		var rightAnchorPixelPosition = Camera.main.WorldToScreenPoint(rightAnchorPosition);

		if(!screenRect.Contains(rightAnchorPixelPosition))
		{
			var lastBlock = transform.GetChild(transform.childCount-1);
			firstBlock.localPosition = lastBlock.localPosition + new Vector3(blockWidth, 0,0);
			firstBlock.SetAsLastSibling();
		}
	}
}
