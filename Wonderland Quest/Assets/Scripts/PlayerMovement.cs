using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    //[SerializeField] private float jumpHeight;
    public Rigidbody2D body;
    private Animator anim;
    private float horizontalInput;
    private bool grounded;

    bool doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        /*if (Input.GetKey(KeyCode.UpArrow))//jump
        {
            if(grounded)
            {
                Jump();
                doubleJump = true;
            }
            else if(doubleJump)
            {
                Jump();
                doubleJump = false;
            }

            
        }*/
        anim.SetBool("running", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

    }
   /* private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpHeight);
        anim.SetTrigger("jump");
        grounded = false;
    }*/
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }*/
    public bool canAttack()
    {
        //return horizontalInput == 0;
        return true;
    }
    
}

