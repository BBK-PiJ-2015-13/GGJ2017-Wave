using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public GameObject DebrisClass;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
			if (other.gameObject.layer == 11) {
			int x=(int)Mathf.Round(Random.Range (3f, 8f));
			for (int i = 0; i < x; i++) {
				GameObject newDeb = Instantiate (DebrisClass, new Vector2((transform.position.x-transform.localScale.x/2+transform.localScale.x/x*i),transform.position.y+Random.Range(0.1f,0.2f)), transform.rotation);
				newDeb.GetComponent<Rigidbody2D> ().mass = GetComponent<Rigidbody2D> ().mass / (x+Random.Range(x*0.1f,x*0.5f));
				newDeb.transform.localScale = new Vector2 (transform.localScale.x/x,transform.localScale.y);
			}
			Destroy (gameObject);
		}
	}
}
