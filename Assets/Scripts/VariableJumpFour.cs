using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableJumpFour : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Jump")]
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
