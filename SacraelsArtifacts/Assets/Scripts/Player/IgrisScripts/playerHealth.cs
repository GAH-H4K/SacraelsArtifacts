using UnityEngine;

public class playerHealth : MonoBehaviour
{

//Script que serao desativados ao morrer(NAO SEI SE È O MELHOR JEITO DE FAZER ISSO MAS FUNCIONA)
    public playerMovement _playerMovement;
    public MeleeAttack meleeAttack;

    [SerializeField] public int health;

    [SerializeField] public int _healthMax = 10;
     
    //private bool isInvicible = false;

    private Rigidbody2D rb;

    public Animator animator;

   
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        health = _healthMax;
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
        _playerMovement.enabled = false;
        meleeAttack.enabled = false;
        animator.SetBool("IsDead", true);
    }

   
    
}
