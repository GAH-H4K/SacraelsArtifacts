using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private float currentSpeed;

    [SerializeField] float jumpForce = 20f;
    [SerializeField] float minJumpHeight = 5f;

    private float moveInput;
    private Rigidbody2D rb;
    private Animator animator;

    public Grounded ground;

    private MeleeAttack meleeAttack;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        currentSpeed = speed;

        ground = GetComponentInChildren<Grounded>();

        meleeAttack = GetComponent<MeleeAttack>();
    }

    void Update()
    {
        Jump();
        Move();
    }

    private void Move()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            moveInput * currentSpeed,
            rb.linearVelocity.y
        );

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

       
        if (meleeAttack != null && meleeAttack.attacking)
            return;

        animator.SetBool(
            "IsRunning",
            moveInput != 0 && ground.isGrounded
        );
    }

    private void Jump()
    {
        bool isGrounded = ground.isGrounded;

        
        if (meleeAttack != null && meleeAttack.attacking)
            return;

        if (!isGrounded)
        {
            bool isRising = rb.linearVelocity.y > 0f;

            animator.SetBool("IsJumping", isRising);
            animator.SetBool("IsFalling", !isRising);
        }
        else
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > minJumpHeight)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                0f
            );
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }
    }
}
    //private void Dash()
    //{
    //   if(Input.GetButtonDown("Dash") && isDashing == false)
    //  {
    //    Debug.Log("falta a logica do dash");
    //    isDashing = true;
    //    currentSpeed = dashForce;
    // }
    // }
