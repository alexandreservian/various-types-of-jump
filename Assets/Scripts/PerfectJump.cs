using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Jump")]
    public float jumpHeight = 3f;
    public float gravityScale = 10f;
    public float fallingGravityScale = 40f;
    private float jumpForce;
    private bool pressedJump;
    private bool releasedJump;

    [Header("Check Ground")]
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = Mathf.Sqrt(-2 * jumpHeight * (Physics2D.gravity.y * gravityScale));
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetButtonDown("Jump")) pressedJump = true;
        releasedJump = (!isGrounded && Input.GetButton("Jump")) ? true : false;
    }

    void FixedUpdate() 
    {
        if (pressedJump) {
            rb.velocity = Vector2.up * jumpForce;
            pressedJump = false;
        }
        

        if(rb.velocity.y >= 0) {
            rb.gravityScale = gravityScale;
        } else if (rb.velocity.y < 0) {
            rb.gravityScale = fallingGravityScale;
        }
    }
}
