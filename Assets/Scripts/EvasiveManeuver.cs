using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour {

	// PUBLIC INSTANCE VARIABLES
	public float dodge;
	public float smoothing;
	public float tilt;
	public Vector2 startWait;  
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	public Boundary boundary;

	// PRIVATE INSTANCE VARIABLES
	private float _currentSpeed;
	private float _targetManeuver;
	private Rigidbody _rigidBody; 
	private Transform _transform;

	void Start () {
		this._rigidBody = gameObject.GetComponent<Rigidbody> ();
		this._transform = gameObject.GetComponent<Transform> ();
		this._currentSpeed = this._rigidBody.velocity.z;

		StartCoroutine (Evade ());
	}

	IEnumerator Evade() {
		yield return new WaitForSeconds(Random.Range(this.startWait.x, this.startWait.y));
		while (true) {
			this._targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(this._transform.position.x);
			yield return new WaitForSeconds(Random.Range(this.maneuverTime.x, this.maneuverTime.y));
			this._targetManeuver = 0;
			yield return new WaitForSeconds(Random.Range(this.maneuverWait.x, this.maneuverWait.y));
		}
	}

	void FixedUpdate () {
		float newManeuver = Mathf.MoveTowards (this._rigidBody.velocity.x, this._targetManeuver, Time.deltaTime * this.smoothing );
		//this._currentSpeed = this._rigidBody.velocity.z;
		this._rigidBody.velocity = new Vector3 (newManeuver, 0.0f, this._currentSpeed);
		this._rigidBody.position = new Vector3 (Mathf.Clamp (this._rigidBody.position.x, this.boundary.xMin, this.boundary.xMax), 
		                                        0.0f, 
		                                        Mathf.Clamp (this._rigidBody.position.z, this.boundary.zMin, this.boundary.zMax));
	
		this._rigidBody.rotation = Quaternion.Euler (0.0f, 0.0f, this._rigidBody.velocity.x * -tilt); 
	}


}
