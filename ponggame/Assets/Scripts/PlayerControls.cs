using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    //code that will determine the keys
    //for paddles1 movement and also the speed of the paddle

    public KeyCode moveup = KeyCode.W;
    public KeyCode movedown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f; //highest position for paddle to go 
    private Rigidbody2D rb2d;
 
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    //tells us what button is pressed, what movement (up/down)
    //if no button is pressed it will remain still
    void Update () {

        var vel = rb2d.velocity;
        if (Input.GetKey(moveup))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(movedown))
        {
            vel.y = -speed;
        }
        else if (!Input.anyKey)
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if(pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
	}
}
