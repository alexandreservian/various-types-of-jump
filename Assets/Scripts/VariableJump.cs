using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20f;
    float jumpTime;
    bool jumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            jumping = true;
            jumpTime = 0;
        }

        if(jumping) {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }

        if(Input.GetButtonUp("Jump") | jumpTime > buttonTime) {
            jumping = false;
        }
    }
}
