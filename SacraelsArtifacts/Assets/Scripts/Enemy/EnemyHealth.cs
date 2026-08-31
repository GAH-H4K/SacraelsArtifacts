using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    public DamagedParticle damagedParticle;
    private int currentParticle = 0;

    private Rigidbody2D rb;

    [SerializeField] private float knockbackForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        Instantiate(damagedParticle.particlePrefab[currentParticle], transform.position, Quaternion.identity);
        health -= damage;

        rb.linearVelocity = Vector2.zero;

        //Knockback maluco talvez desnecessário q eu provavelmente vou remover depois, ou por em outro inimigo, sla

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

