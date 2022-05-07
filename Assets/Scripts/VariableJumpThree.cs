using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableJumpThree : MonoBehaviour
{
    private Rigidbody2D rb;
    [Range(0, 5f)] [SerializeField] private float fallLongMult = 0.85f;
    [Range(0, 5f)] [SerializeField] private float fallShortMult = 1.55f;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool pressedJump;
    private bool releasedJump;
    public float jumpForce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetButtonDown("Jump")) pressedJump = true;
        releasedJump = (!isGrounded && Input.GetButton("Jump")) ? true : false;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(feetPos.position, checkRadius);
    }

    void FixedUpdate() {
        if (pressedJump) {
            rb.velocity = Vector2.up * jumpForce;
            pressedJump = false;
        }
        if(releasedJump && rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallLongMult - 1) * Time.fixedDeltaTime;
        }
        else if(!releasedJump && rb.velocity.y > 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallShortMult - 1) * Time.fixedDeltaTime;
        }
    }
}
