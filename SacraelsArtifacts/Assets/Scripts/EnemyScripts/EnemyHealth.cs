using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;

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

        void Die()
        {
            Destroy(gameObject);
        }
    }
}
