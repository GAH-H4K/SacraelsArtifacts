using UnityEngine;
public class MeleeAttack : MonoBehaviour
{
    public Transform attackPoint;

    public Vector2 attackSize = new Vector2(1.5f, 1f);

    public float attackRange = 0.5f;
    
    public LayerMask enemyLayers;
    
    public int attackDamage = 20;

    private Animator animator;

    public bool isAttacking = false;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AttackFunction();
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    void AttackFunction()
   {
    Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(
        attackPoint.position,
        attackSize,
        0f,
        enemyLayers
    );
  
    foreach (Collider2D enemy in hitEnemies)
     {
            Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
         enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage, knockbackDirection);
     }
   }

    void OnDrawGizmosSelected()
   {
     if (attackPoint == null)
        return;

      Gizmos.color = Color.red;

     Gizmos.DrawWireCube(

        attackPoint.position,
        attackSize
        
        );
   }
}
