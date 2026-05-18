using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;

    private Rigidbody2D rb;

    private int Speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * Speed, rb.linearVelocity.y);

    }

}

