using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float scrollSpeed; 
	public float tileSizeZ;

	// PRIVATE INSTANCE VARIABLES
	private Vector3  _startPosition;

	// Use this for initialization
	void Start () {
		this._startPosition = gameObject.GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () { 
		float newPosition = Mathf.Repeat (Time.time * this.scrollSpeed, this.tileSizeZ);
		gameObject.GetComponent<Transform> ().position = this._startPosition + Vector3.forward * newPosition;
	}
}
