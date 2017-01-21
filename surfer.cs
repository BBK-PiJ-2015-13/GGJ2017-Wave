using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfer : MonoBehaviour {

    public bool struck = false;
    public float bounce;

    // Use this for initialization
    void Start () {
       }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "wave")
        {
            struck = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, bounce);
        }

    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "surface")
        {
           
            if (struck)
            {
                GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }

}
