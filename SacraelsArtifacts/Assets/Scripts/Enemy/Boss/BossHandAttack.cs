using UnityEngine;

public class BossHandAttack : MonoBehaviour
{
    public GameObject Hand1;
    public GameObject Hand2;


    private bool OneHandIsAttacking = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
           
            
            playerHealth playerHealth = collision.gameObject.GetComponent<playerHealth>();
            if (playerHealth != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                float knockbackForce = 5f; 
                playerHealth.TakeDamage(1, knockbackDirection, knockbackForce);
            }

           
        }
    }

}
