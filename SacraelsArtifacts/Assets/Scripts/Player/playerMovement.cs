using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed;

    public float currentSpeed;

    [SerializeField] float jumpForce = 10f; 

    [SerializeField] float dashSpeed;

    private float moveInput;

    private Rigidbody2D rb;

    private bool isOnGround;

  



 
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }
 
    void Update()
    {      
        Jump();
        //movimento horizontal
        Move();
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(moveInput * currentSpeed, rb.linearVelocity.y);

         if(moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Jump()
    {
        if(Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0) 

        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            
        }

        if(Input.GetButtonDown("Jump") && isOnGround)

        {
                
              rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);


         }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

   

    

}

