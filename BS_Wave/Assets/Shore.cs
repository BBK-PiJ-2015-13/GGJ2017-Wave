using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shore : MonoBehaviour {

	public Camera main;
	public int timer = 300;
	public bool startTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer) {
			if (timer > 0) {
				timer--;
			} else {
				main.GetComponent<Main>().showScore=true;
				startTimer = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.layer == 11) {
			other.gameObject.GetComponent<WaveScript>().ashore = true;
			Destroy (other.gameObject.GetComponent<PolygonCollider2D> ());
			startTimer = true;
		}
	}
}
