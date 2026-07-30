using UnityEngine;

public class playerHealth : MonoBehaviour
{

     public int health = 5;
     
     private bool isInvicible = false;

     private Rigidbody2D rb;
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockbackDirection, float knockbackForce)
    {
        
        health -= damage;

        rb.linearVelocity = Vector2.zero;

        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);



        if (health <= 0)
        {
            Die();
        }

        
    }
    public void Die()
        {
            Destroy(gameObject);
        }

   
    
}
