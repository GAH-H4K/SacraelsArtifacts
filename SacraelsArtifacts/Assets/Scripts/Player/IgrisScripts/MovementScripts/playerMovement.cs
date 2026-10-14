using UnityEngine;
using System.Collections;

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

    public bool JumpBufferActive = false;

    public bool jumpHeld = false;

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
        if (Input.GetButtonDown("Jump"))
        {
            jumpHeld = true;

            if (ground.isGrounded)
            {
                MoveUp();
            }
            else
            {
                StartCoroutine(JumpBuffer());
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpHeld = false;

            if (rb.linearVelocity.y > minJumpHeight)
            {
                rb.linearVelocity = new Vector2(
                    rb.linearVelocity.x,
                    0f
                );
            }
        }

        if (JumpBufferActive)
        {
            if (ground.isGrounded)
            {

                MoveUp();
                JumpBufferActive = false;

                if (!jumpHeld && rb.linearVelocity.y > minJumpHeight)
                {
                    rb.linearVelocity = new Vector2(
                        rb.linearVelocity.x,
                        0f
                    );
                }
            }

        }
    }

    private void MoveUp()
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce
        );

        animator.SetBool("IsJumping", true);
    }

    IEnumerator JumpBuffer()
    {
        JumpBufferActive = true;
        yield return new WaitForSeconds(0.15f);
        JumpBufferActive = false;
    }


    public void AnimatorParameters()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));

        animator.SetFloat("yVelocity", (rb.linearVelocity.y));
    }
}

