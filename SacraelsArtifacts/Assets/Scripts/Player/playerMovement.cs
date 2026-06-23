using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public float currentSpeed;
    public float jumpForce = 10f; 
    [SerializeField] float dashSpeed;
    private Rigidbody2D rb;
    private float moveInput;
    private bool isOnGround;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }
 
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        //linhas pra mexer o sprite pros lado(/?????)
        if(moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //pulo

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround)
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

