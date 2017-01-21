using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollwaves : MonoBehaviour {
    private Vector2 myDirection;
    private float myX;
    private float myY;
    private bool up;
    private bool down;
    public float speed;
    private int range;
    

    // Use this for initialization
    void Start()
    {
        up = true;
        down = false;
        myDirection = new Vector2(0.0f, myY);
    }

    void FixedUpdate()
    {
        //Controls the enemy object's movements - moves up and down within the range set by the public range value.
        if (range > 50 || up)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 1.0f) * speed;
            down = false;
            up = true;
            range--;
        }
        if (range <= -50 || down)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(1.0f, 1.0f) * -speed;
            myY = 100.0f;
            up = false;
            down = true;
            range++;
        }
    }
}
