using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icecream : Object
{
    GameManager gm;
    public Rigidbody2D rb;

    public string colour;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();

        //Starting velocity
        rb.velocity = new Vector2(0, -3);       

        base.Start();

        //will need to collide with the bototm of scoop, so platform is turned off
        pf.enabled = false;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If it hit the platform collider
        if (collision.enabled)
        {
            //If the collider is the player (cone or caught scoops)
            if (collision.gameObject.CompareTag("Player") && enabled)
            {
                Object obj = collision.gameObject.GetComponent<Object>();

                //Freeze scoop
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;

                //Become child of the cone/player
                transform.parent = collision.transform;                            

                //Turn on this scoops platform collider **Only things colliding with the top of the scoop can collide
                pf.enabled = true;

                //Remove the scoop belows collision
                obj.RemoveBoxColider();
                obj.RemoveBoxColider();

                //We caught the scoop!
                gm.DoNextThing(this);

                //Disable code from this scoop
                enabled = false;               
            }
        }

        //Collide with the bottom of the screen
        if(collision.gameObject.CompareTag("Death"))
        {
            gm.GameOver();
            Destroy(this);
        }
    }
    
}
