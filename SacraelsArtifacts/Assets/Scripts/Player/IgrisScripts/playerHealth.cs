using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour
{

    //Script que serao desativados ao morrer(NAO SEI SE È O MELHOR JEITO DE FAZER ISSO MAS FUNCIONA)
    public playerMovement _playerMovement;
    public MeleeAttack meleeAttack;

    [SerializeField] public int health;

    [SerializeField] public int _healthMax = 10;

    [SerializeField] public int InvincibilityFlashes = 4;

    public PauseMenu PauseScript;

    private SpriteRenderer spriteRend;
    private Rigidbody2D rb;

    private Animator animator;

    public GameObject canvasDeath;


    void Start()
    {
        spriteRend = GetComponentInChildren<SpriteRenderer>();

        canvasDeath.SetActive(false);

        animator = GetComponentInChildren<Animator>();

        health = _healthMax;

        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockbackDirection, float knockbackForce)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Invincibility());

            rb.linearVelocity = Vector2.zero;

            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        }

    }

    private IEnumerator Invincibility()
    {
        // layer 7 = inimigo e layer 8 = player
        Physics2D.IgnoreLayerCollision(8, 7, true);

        for (int i = 0; i < InvincibilityFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRend.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.1f);
        }

        Physics2D.IgnoreLayerCollision(8, 7, false);
    }

    public void Die()
    {
        rb.linearVelocity = Vector2.zero;

        _playerMovement.enabled = false;

        meleeAttack.enabled = false;

        animator.SetBool("IsDead", true);

        canvasDeath.SetActive(true);

        PauseScript.CanPause = false;
    }


}