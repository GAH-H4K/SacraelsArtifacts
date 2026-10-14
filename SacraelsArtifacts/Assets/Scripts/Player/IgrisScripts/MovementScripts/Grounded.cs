using UnityEngine;
using System.Collections;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;
    public int groundContacts = 0;

    public Animator animator;

    public bool CoyoteTimerActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts++;
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

    IEnumerator CoyoteTimer()
    {
        CoyoteTimerActive = true;
        yield return new WaitForSeconds(0.15f);
        isGrounded = false;
        CoyoteTimerActive = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StartCoroutine(CoyoteTimer());
            groundContacts--;

            if (groundContacts <= 0 && !CoyoteTimerActive)
            {
                isGrounded = false;
            }

        }
    }

}
