using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 vel;

    //choose random direction (lef/right), ball will then move
    void MoveBall()
    {
        float rand = Random.Range(0, 2);
        if (rand  < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("MoveBall", 2);//will give 2 seconds waiting time for player to prepare, then MoveBall function will start
	}

    //resets ball to center, when goal is scored and from one level to another
    void Resetball(){
        vel = Vector2.zero;
        rb2d.velocity = vel;
        transform.position = Vector2.zero;
    }

    //waits for ball to hit paddle, velocity of ball is adjusted alongside the speed of the paddle
   void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("paddle1"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }

    void Update () {
		
	}
}
