using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wave_movement : MonoBehaviour {

    public float speed;
    public float distance;
    public float slowdown;
    public float minimum;
    public Slider heightSlider;
    public float maxheight;

    // Use this for initialization
    void Start () {
        maxheight = 100;
        heightSlider.maxValue = maxheight;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 Rightmovement = new Vector2(-slowdown, 0);
            GetComponent<Rigidbody2D>().velocity = Rightmovement / speed;
            distance--;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            slowdown += Time.deltaTime;
            Vector2 Rightmovement = new Vector2(-slowdown, 0);
            GetComponent<Rigidbody2D>().velocity = Rightmovement * speed;
            distance++;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            slowdown = minimum;
        }
      

        if (distance >= 0)
        {
            //transform.localScale = new Vector2(distance, distance);
        }
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        distance += moveHorizontal /10;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
        if(distance <= -distance)
        {
            transform.localScale = new Vector2(distance, -distance);
        }*/


        if (distance > 100)
        {
            //Destroy(this.gameObject);
            //SceneManager.LoadScene("gameover");
        }

        heightSlider.value = distance;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "surfer")
        {
            //transform.localScale = new Vector2(7.5f, 7.5f);
        }
        if (other.collider.tag == "beach")
        {
            SceneManager.LoadScene("victory");
        }
    }
}
