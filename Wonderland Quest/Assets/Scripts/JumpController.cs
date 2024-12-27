using UnityEngine;

public class JumpController : MonoBehaviour
{

    public Rigidbody2D rgbody;

    //[Header("Jump System")]
    //[SerializeField] float jumpTime;
    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;
    //[SerializeField] float jumpMultiplier;



    public Transform groundCheck;
    public LayerMask groundLayer;
    // //bool isGrounded;
    Vector2 vecGravity;

    bool isJumping;
    float jumpCounter;
    bool doubleJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rgbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))//
        {
            if (isGrounded())
            {
                rgbody.linearVelocity = new Vector2(rgbody.linearVelocity.x, jumpPower);
                doubleJump = true;
            }
            else if (doubleJump)
            {
                rgbody.linearVelocity = new Vector2(rgbody.linearVelocity.x, jumpPower);
                doubleJump = false;
            }
           // isJumping = true;
           // jumpCounter = 0;

        }
       /* if (rgbody.linearVelocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if(t > 0.3f)
            {
                currentJumpM = jumpMultiplier * (1-t);
            }

            rgbody.linearVelocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            isJumping = false;
            jumpCounter = 0;
            if(rgbody.linearVelocity.y > 0)
            {
                rgbody.linearVelocity = new Vector2(rgbody.linearVelocity.x, rgbody.linearVelocity.y * 0.4f);
            }
        }*/

        if (rgbody.linearVelocity.y < 0)
        {
            rgbody.linearVelocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.2f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
