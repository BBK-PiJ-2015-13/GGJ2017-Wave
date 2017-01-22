using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
	public float breakEnergy = 10f;
	public int score=2;
	public Camera main;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D collider)
	{
		if ( KineticEnergy (collider.gameObject.GetComponent<Rigidbody2D>()) >= breakEnergy){
			main.GetComponent<Main>().score+=score;
			Destroy (gameObject);
		}

	}
	public static float KineticEnergy(Rigidbody2D rb){
		// mass in kg, velocity in meters per second, result is joules
		return 0.5f*rb.mass*Mathf.Pow(rb.velocity.magnitude,2);
	}
}
