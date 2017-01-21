using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == 11) {
			Debug.Log ("ayy");
			GetComponent<Rigidbody2D> ().AddTorque (-5f);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (5f,5f));
		}
	}
}
