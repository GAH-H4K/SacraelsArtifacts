using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int health = 50;
    public DamagedParticle damagedParticle;
    private int currentParticle = 0;

    private Rigidbody2D rb;

    public float HitStopDuration = 0.1f; 

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

        GameFeelManager.Instance.HitStop(HitStopDuration);

        if (health <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashRed()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

    public void Die()
    {
       Destroy(gameObject);
    }
    
}

