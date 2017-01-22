using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Main : MonoBehaviour {

	public int score;
	public Text scoreTxt;
	public bool showScore;
	public Slider sl;
	public Image handle;

	public GameObject waveClass;
	// Use this for initialization
	void Start () {
		GameObject wave = Instantiate (waveClass, new Vector2(transform.position.x,transform.position.y), transform.rotation);
		wave.GetComponent<WaveScript>().cam = gameObject;
		wave.GetComponent<WaveScript> ().sl = sl;
		wave.GetComponent<WaveScript> ().handle = handle;
	}
	
	// Update is called once per frame
	void Update () {
		if (showScore) {
			scoreTxt.text = "Score: " + score;
			scoreTxt.enabled = true;
		} else {
			scoreTxt.enabled = false;
		}
	}
}
