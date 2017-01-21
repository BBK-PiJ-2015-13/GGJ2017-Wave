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
    public float up;
    public Vector2 baseWave;
    public float baseDistance;
    private Transform ocean;
    public float sealevel;
    public float initialV;

    // Use this for initialization
    void Start() {
        up = transform.position.y;
        //transform.localScale = baseWave;
        distance = baseDistance * 10;
        ocean = GameObject.Find("waterline").transform;
        sealevel = ocean.transform.position.x;
        GetComponent<Rigidbody2D>().velocity = new Vector2();
        if (sealevel < 0)
        {
            sealevel = sealevel * -1;
        }
        maxheight = 10;//sealevel + (sealevel / 100 * 40);
        heightSlider.maxValue = maxheight;
        heightSlider.value = transform.lossyScale.y; //GetComponent<BoxCollider2D>().size.y;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (slowdown > 1)
            {
                slowdown -= Time.deltaTime;
            }
            
            Vector2 Rightmovement = new Vector2(-slowdown, 0.0f);
            GetComponent<Rigidbody2D>().velocity = Rightmovement *10 / speed;
            if (distance > 0)
            {
                distance--;
                //GetComponent<Rigidbody2D>().velocity = transform.up * speed;
                heightSlider.value = distance / 10;
            }
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            slowdown += Time.deltaTime;
            Vector2 Rightmovement = new Vector2(-slowdown, 0.0f);
            GetComponent<Rigidbody2D>().velocity = Rightmovement * speed;
            distance++;
            heightSlider.value = distance / 10;
            //GetComponent<Rigidbody2D>().velocity = transform.up * -speed;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            slowdown = minimum;
        }
      

        if (distance >= 0)
        {

            //transform.localScale = new Vector2(distance /10, distance /10);


        }
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        distance += moveHorizontal /10;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
        if(distance <= -distance)
        {
            transform.localScale = new Vector2(distance, -distance);
        }*/


        if (heightSlider.value == heightSlider.maxValue || heightSlider.value <= 0)
        {
            //Destroy(this.gameObject);
            //SceneManager.LoadScene("gameover");
        }
       
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "surfer")
        {
            //transform.localScale = new Vector2(7.5f, 7.5f);
        }
        if (other.collider.tag == "beach") { 
            if (heightSlider.value < heightSlider.maxValue / 2)
            {
                SceneManager.LoadScene("feeble");
            }
        else
        {
                carryover x = other.gameObject.GetComponent("carryover") as carryover;
                x.thescore((int) distance + (int) slowdown);
                //x.yourscore = (int)distance + (int)slowdown;
                SceneManager.LoadScene("victory");
        }
        }
    }
}
