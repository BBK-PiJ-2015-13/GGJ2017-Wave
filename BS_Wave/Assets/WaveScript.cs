using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour
{
	public GameObject cam;
	public GameObject spwn;
	private GameObject spawnerInstance1;
	private GameObject spawnerInstance2;
	public Rigidbody2D rb2d;
	public bool ashore;
	private int life=100;
	public Color col;
	public float maxVel=10f;
	public float minVel=2f;
	public Slider sl;
	public Image handle;

	// Use this for initialization
	void Start ()
	{
		/*spawnerInstance1 = Instantiate (spwn, new Vector2 (transform.position.x + 0.7f, transform.position.y - 0.7f), transform.rotation);
		spawnerInstance1.GetComponent<SplashGen> ().particleVelocity = new Vector2 (-4f, 0f);
		spawnerInstance2 = Instantiate (spwn, new Vector2 (transform.position.x + 0.9f, transform.position.y - 4.7f), transform.rotation);
		spawnerInstance2.GetComponent<SplashGen> ().particleVelocity = new Vector2 (-0.8f, 2f);
		spawnerInstance2.GetComponent<SplashGen> ().particleLayer =9;
		spawnerInstance2.GetComponent<SplashGen> ().particleGravity = 0.6f;*/
		GetComponent<SpriteRenderer> ().color =col;
		rb2d.velocity = new Vector2 (4f, 0f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (!ashore) {
			//transform.localScale =new Vector2(1.0f + 0.1f * Mathf.Cos ((float)Time.frameCount/12),1.0f - 0.1f * Mathf.Cos ((float)Time.frameCount/12));
			/*spawnerInstance1.transform.position = new Vector2 (transform.position.x+0.7f, transform.position.y-0.7f);
		spawnerInstance2.transform.position = new Vector2 (transform.position.x+0.9f, transform.position.y+0.9f);*/
			cam.transform.position = new Vector3 (transform.position.x, transform.position.y, -10.0f);
			cam.GetComponent<Camera> ().orthographicSize = 3f + 1f * Mathf.Log (Mathf.Abs (rb2d.velocity.x) + 2, 1.5f) / 3;
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
			transform.localScale = new Vector2 (1f * Mathf.Log (Mathf.Abs (rb2d.velocity.x / 3) + 2, 2f), 1f * Mathf.Log (Mathf.Abs (rb2d.velocity.x / 3) + 2, 2f));
			if (Input.GetAxis ("Horizontal")>0)
			rb2d.velocity = (new Vector2 (rb2d.velocity.x + Input.GetAxis ("Horizontal") / 10, 0f));
			GetComponent<BuoyancyEffector2D> ().density = 1f * rb2d.velocity.x / 3 * rb2d.velocity.x / 3;
			GetComponent<BuoyancyEffector2D> ().flowAngle = 45*(1-rb2d.velocity.x/maxVel);
			GetComponent<BuoyancyEffector2D> ().flowMagnitude = 5f * rb2d.velocity.x / 3;
			sl.value = rb2d.velocity.x;
			handle.color = Color.Lerp (Color.red, Color.green, (4 - Mathf.Abs ((rb2d.velocity.x-6)))/4);
			if (rb2d.velocity.x > maxVel||rb2d.velocity.x < minVel) {
				ashore = true;
				cam.GetComponent<Main>().showScore=true;
			}
		} else {
			if (life > 0) {
				life--;
				GetComponent<SpriteRenderer> ().color = new Color (col.r, col.g, col.b, 1.1f * life / 100);
				transform.localScale = new Vector2 (1f * Mathf.Log (Mathf.Abs (rb2d.velocity.x / 3) + 2, 2f)*life/100, 1f * Mathf.Log (Mathf.Abs (rb2d.velocity.x / 3) + 2, 2f)*life/100);
			} else {
				Destroy (gameObject);
			}
		}
	}
}