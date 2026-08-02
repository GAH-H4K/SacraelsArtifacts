using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
           
            
            playerHealth playerHealth = collision.gameObject.GetComponent<playerHealth>();
            
            if (playerHealth == null)
            {
                Debug.LogError("o script n ta no player dumbass");
            }

            if (playerHealth != null)
            {
                
                
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                float knockbackForce = 5f; 
                playerHealth.TakeDamage(1, knockbackDirection, knockbackForce);
            }

           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
