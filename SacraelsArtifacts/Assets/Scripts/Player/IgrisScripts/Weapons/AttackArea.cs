using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int Damage = 10;

    public Vector2 knockbackForce;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.TakeDamage(Damage, knockbackForce);
        }
    }
}
