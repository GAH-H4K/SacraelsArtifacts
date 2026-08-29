using UnityEngine;

public class Grounded : MonoBehaviour
{
    public bool isGrounded;
    public int groundContacts = 0;
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts++;
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            groundContacts--;
            
            if (groundContacts <= 0)
            {
                isGrounded = false;
            }
        }
    }
    // Update is called once per frame
  
}
