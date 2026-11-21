using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public int Damage = 1;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
           
            
            playerHealth playerHealth = collision.gameObject.GetComponent<playerHealth>();
            if (playerHealth != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                float knockbackForce = 5f; 
                playerHealth.TakeDamage(Damage, knockbackDirection, knockbackForce);
            }

           
        }
    }
}
