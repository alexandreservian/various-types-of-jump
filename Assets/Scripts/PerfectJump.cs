using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectJump : MonoBehaviour
{
    public float jumpHeight = 3f;
    public float gravityScale = 10f;
    public float fallingGravityScale = 40f;
    private float jumpForce;
    private Rigidbody2D rb;
    public bool jumping = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = Mathf.Sqrt(-2 * jumpHeight * (Physics2D.gravity.y * gravityScale));
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump")){
            jumping = true;
        }

        // if(Input.GetButtonUp("Jump")) {
        //     jumping = false;
        // }
    }

    void FixedUpdate() 
    {
        if(jumping) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumping = false;
        }

        if(rb.velocity.y >= 0) {
            rb.gravityScale = gravityScale;
        } else if (rb.velocity.y < 0) {
            rb.gravityScale = fallingGravityScale;
        }
    }
}
