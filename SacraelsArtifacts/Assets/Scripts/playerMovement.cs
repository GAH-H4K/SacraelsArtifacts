using UnityEngine;
public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private Vector1 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }
}