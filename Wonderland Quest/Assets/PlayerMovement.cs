using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float jumpForce;
    public Rigidbody2D body;

    private bool isGrounded; // To check if the player is on the ground
    private int jumpCount;   // To track the number of jumps

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isGrounded = true;
        jumpCount = 0;
    }

    void Update()
    {
        // Horizontal movement
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);

        // Jump logic
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded || jumpCount < 2)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
                jumpCount++;
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jump count when the player lands
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
}
