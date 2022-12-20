using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = .5f;
    public float dragScale = .9f;
    public float jumpForce = 1.0f;

    public GameObject spriteObject;


    private bool onGround;
    private Rigidbody2D body;

    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Jump");

        if(body.velocity.y == 0)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }


        //process l/r movement
        if (horizontalInput != 0)
        {
            body.velocity = new Vector2(horizontalInput * moveSpeed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(body.velocity.x * dragScale * Time.deltaTime, body.velocity.y);
        }


        //process jump input
        if(jump > 0 && onGround)
        {
            body.AddForce(new Vector2(0, jumpForce));
        }



        //flip sprite on direction change
        if(horizontalInput > 0)
        {
            spriteObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
