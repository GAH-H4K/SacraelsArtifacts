using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour
{

    [SerializeField] float speed;
    private float currentSpeed;
    [SerializeField] float jumpForce = 20f; 
    [SerializeField] float minJumpHeight = 5f;
    
    [SerializeField] float dashForce = 20f;
    private float moveInput;
    private Rigidbody2D rb;

   
    private bool isDashing = false;
    //private bool isJumping = false;
    private Animator animator;
    public Grounded ground;
 
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody2D>();

        currentSpeed = speed;

        ground = GetComponentInChildren<Grounded>();

    }
 
    void Update()
    {      
        Jump();
     
        Move();

        Dash();
    
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        animator.SetBool("IsRunning", moveInput != 0);


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
        if(Input.GetButtonUp("Jump") && rb.linearVelocity.y > minJumpHeight) 

        {
             rb.linearVelocity = new Vector2(rb.linearVelocity.y, 0f); 
        }

        if(Input.GetButtonDown("Jump") && ground.isGrounded)

        {
                
              rb.linearVelocity = new Vector2(rb.linearVelocity.y, jumpForce);
        }

    }

    private void Dash()
    {
        if(Input.GetButtonDown("Dash") && isDashing == false)
        {
            Debug.Log("falta a logica do dash");

            isDashing = true;
            currentSpeed = dashForce;
            
        }
    }

}

