using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTimer : MonoBehaviour {

	private int timer=200;
	private Color col;

	// Use this for initialization
	void Start () {
		col = GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer--;
			//GetComponent<SpriteRenderer>().color = new Color (1f, 1f*timer/400, 0.2f*timer/200, 1.2f * timer / 200);
			GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 1.2f * timer / 200);
			transform.localScale = new Vector2 (1f*timer/200,1f*timer/200);
		} else {
			Destroy (gameObject);
		}
	}
}
