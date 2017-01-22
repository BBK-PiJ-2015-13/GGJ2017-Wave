using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == 11) {
			GetComponent<Rigidbody2D> ().AddTorque (-1f*GetComponent<Rigidbody2D>().mass*GetComponent<Rigidbody2D>().mass);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (2f,2f));
		}
	}
}
