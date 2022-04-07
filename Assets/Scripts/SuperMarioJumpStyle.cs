using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMarioJumpStyle : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpAmount = 10f;
    public float gravityScale = 10f;
    public float fallingGravityScale = 40;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if(rb.velocity.y >= 0) {
            rb.gravityScale = gravityScale;
        } else if(rb.velocity.y < 0) {
            rb.gravityScale = fallingGravityScale;
        }
    }
}
