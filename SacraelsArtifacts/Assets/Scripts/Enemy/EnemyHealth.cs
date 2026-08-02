using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;

    private Rigidbody2D rb;

    [SerializeField] private float knockbackForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        health -= damage;

        rb.linearVelocity = Vector2.zero;

        //Knockback maluco talvez desnecessário q eu provavelmente vou remover depois, ou por em outro inimigo, sla

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
