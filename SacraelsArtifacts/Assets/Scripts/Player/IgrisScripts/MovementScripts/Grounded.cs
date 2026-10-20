using UnityEngine;
using System.Collections;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;
    public int groundContacts = 0;

    public Animator animator;

    public bool CoyoteTimerActive = false;

    public playerMovement playerMovementScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts++;
            isGrounded = true;
        }
    }

    public IEnumerator CoyoteTimer()
    {
        CoyoteTimerActive = true;

        isGrounded = true;

        yield return new WaitForSeconds(0.2f);

        CoyoteTimerActive = false;

        if (groundContacts <= 0)
        {
            isGrounded = false;
        }

    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            groundContacts--;

            if (groundContacts <= 0 && !CoyoteTimerActive)
            {
                isGrounded = false;
            }

            if (playerMovementScript.jumpHeld)
            {
                //does nothing and dies
            }
            else
            {
                StartCoroutine(CoyoteTimer());
            }
        }
    }

}
