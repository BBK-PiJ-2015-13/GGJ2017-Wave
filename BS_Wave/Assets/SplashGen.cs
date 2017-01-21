using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SplashGen : MonoBehaviour {
	public GameObject spl;
	public Vector2 particleVelocity=new Vector2(0.0f,0.0f);
	public int particleLayer = 8;
	public float particleGravity=0.3f;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0f);
	}

	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 5 == 0) {
			GameObject newSpl=Instantiate (spl,transform.position,transform.rotation);
			newSpl.layer = particleLayer;
			newSpl.GetComponent<Rigidbody2D>().velocity =particleVelocity;
			newSpl.GetComponent<Rigidbody2D>().gravityScale =particleGravity;
		}
	}
}
