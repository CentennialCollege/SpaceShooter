 using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate; 
	public float delay; 


	// PRIVATE INSTANCE VARIABLES
	private AudioSource _audioSource;

	void Start () {
		this._audioSource = gameObject.GetComponent<AudioSource> (); 
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire() {
		Instantiate (shot, shotSpawn.position, shotSpawn.rotation);  
		this._audioSource.Play ();
	}
}
