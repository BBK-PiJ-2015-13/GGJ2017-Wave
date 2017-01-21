using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public GameObject waveClass;
	// Use this for initialization
	void Start () {
		GameObject wave = Instantiate (waveClass, new Vector2(transform.position.x,transform.position.y), transform.rotation);
		wave.GetComponent<WaveScript>().cam = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
