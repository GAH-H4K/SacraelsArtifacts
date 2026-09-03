using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;
    public int groundContacts = 0;

    public Animator animator;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts++;
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts--;

            if (groundContacts <= 0)
            {
                isGrounded = false;
            }

        }
    }

}
