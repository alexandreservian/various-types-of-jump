using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PerfectJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Jump")]
    public float jumpForce = 10f;
    public float fallMultiplier = 1f;
    public float lowJumpFallMultiplier = 1f;
    private bool jumpButtonPressed = false;
    private bool jumpButtonPressing = false;

    [Header("Check Ground")]
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float mod = 0f;
    private float initalGravityScale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        jumpButtonPressed = Input.GetButtonDown("Jump");
        jumpButtonPressing = Input.GetButton("Jump");

    }

    void FixedUpdate() 
    {
        if(jumpButtonPressed && isGrounded) {
            rb.velocity = Vector2.up * jumpForce;
        }

        if(rb.velocity.y < 0f) {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0f &&  !jumpButtonPressing) {
            rb.gravityScale = lowJumpFallMultiplier;
        }
        else {
            rb.gravityScale = initalGravityScale;
        }
    }
}
