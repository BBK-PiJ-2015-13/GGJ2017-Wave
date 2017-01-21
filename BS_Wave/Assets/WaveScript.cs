using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
	public GameObject cam;
	public GameObject spwn;
	private GameObject spawnerInstance1;
	private GameObject spawnerInstance2;
	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		/*spawnerInstance1 = Instantiate (spwn, new Vector2 (transform.position.x + 0.7f, transform.position.y - 0.7f), transform.rotation);
		spawnerInstance1.GetComponent<SplashGen> ().particleVelocity = new Vector2 (-4f, 0f);
		spawnerInstance2 = Instantiate (spwn, new Vector2 (transform.position.x + 0.9f, transform.position.y - 4.7f), transform.rotation);
		spawnerInstance2.GetComponent<SplashGen> ().particleVelocity = new Vector2 (-0.8f, 2f);
		spawnerInstance2.GetComponent<SplashGen> ().particleLayer =9;
		spawnerInstance2.GetComponent<SplashGen> ().particleGravity = 0.6f;*/
	}

	// Update is called once per frame
	void Update ()
	{
		//transform.localScale =new Vector2(1.0f + 0.1f * Mathf.Cos ((float)Time.frameCount/12),1.0f - 0.1f * Mathf.Cos ((float)Time.frameCount/12));
		/*spawnerInstance1.transform.position = new Vector2 (transform.position.x+0.7f, transform.position.y-0.7f);
		spawnerInstance2.transform.position = new Vector2 (transform.position.x+0.9f, transform.position.y+0.9f);*/
		cam.transform.position = new Vector3 (transform.position.x, transform.position.y, -10.0f);
		cam.GetComponent<Camera> ().orthographicSize = 3f + 1f * Mathf.Log(Mathf.Abs(rb2d.velocity.x)+2, 1.5f)/3;
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
		transform.localScale=new Vector2(1f * Mathf.Log(Mathf.Abs(rb2d.velocity.x/3)+2, 2f),1f * Mathf.Log(Mathf.Abs(rb2d.velocity.x/3)+2, 2f));
		rb2d.velocity =(new Vector2(rb2d.velocity.x-Input.GetAxis ("Horizontal")/10,0f));
		GetComponent<BuoyancyEffector2D> ().density = 1f * rb2d.velocity.x/3*rb2d.velocity.x/3;
		GetComponent<BuoyancyEffector2D> ().flowMagnitude = 1f * rb2d.velocity.x/3;
	}
}