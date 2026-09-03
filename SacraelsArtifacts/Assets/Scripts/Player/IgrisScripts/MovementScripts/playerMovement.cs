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
        AnimatorParameters();
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

    }

    private void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > minJumpHeight)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                0f
            );
        }

        if (Input.GetButtonDown("Jump") && ground.isGrounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );

            animator.SetBool("IsJumping", true);
        }
    }


    public void AnimatorParameters()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));

        animator.SetFloat("yVelocity", (rb.linearVelocity.y));
    }
}

