using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToSpecificHeight : MonoBehaviour
{    
    private Rigidbody2D rb;
    private float jumpForce; 
    public float maxJumpHeight = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = Mathf.Sqrt(maxJumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }   
}
