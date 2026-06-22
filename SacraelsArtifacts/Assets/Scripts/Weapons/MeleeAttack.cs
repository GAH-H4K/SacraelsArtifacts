using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform attackPoint;

    public Vector2 attackSize = new Vector2(1.5f, 1f);

    public float attackRange = 0.5f;
    
    public LayerMask enemyLayers;
    
    public int attackDamage = 20;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AttackFunction();
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
  
    foreach (Collider2D enemy in hitEnemies);
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
