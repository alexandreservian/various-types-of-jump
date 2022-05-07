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
    public float jumpForce = 10f;
    private bool pressedJump;
    private bool releasedJump;

    [Header("Check Ground")]
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float mod = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //jumpForce = Mathf.Sqrt(-2 * jumpHeight * (Physics2D.gravity.y * gravityScale));
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetButtonDown("Jump")) pressedJump = true;
        if ((!isGrounded && Input.GetButtonUp("Jump"))) releasedJump = true;
    }

    void FixedUpdate() 
    {
        if (pressedJump) {
            rb.velocity = Vector2.up * jumpForce;
            pressedJump = false;
        }

        if(releasedJump) {
            Debug.Log("Saida " + rb.velocity.y);
            if(rb.velocity.y > 0) {
                rb.velocity = Vector2.zero;
                rb.velocity = Vector2.up * mod;
                Debug.Log("Diferenca " + Physics2D.gravity.y * (0.85f - 1) * Time.fixedDeltaTime);
                Debug.Log("Saida dois " + rb.velocity.y);
            }
            releasedJump = false;
        }
    }
}
