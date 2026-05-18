using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
       public float speed = 5f;
 
    private Rigidbody2D rb;
    private float moveInput;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if(moveInput > 0)
        {
            transfomr
        }
    
    }
 
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

}

