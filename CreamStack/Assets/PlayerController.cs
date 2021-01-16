using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Object
{
    Rigidbody2D rb;
    public float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        base.Start();
    }


    // Update is called once per frame
    void Update()
    {
        //Move Left and right using A and D keys
        //When not pressing change velocity back to 0

        if(Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-moveSpeed, 0);

            //Player can only move to the edge of the screen
            if(transform.position.x < -7)
            {
                transform.position = new Vector2(-7, transform.position.y);
            }
        }         
        else if(Input.GetKey("d"))
        {
            rb.velocity = new Vector2(moveSpeed, 0);

            //Player can only move to the edge of the screen
            if (transform.position.x > 7)
            {
                transform.position = new Vector2(7, transform.position.y);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
