using UnityEngine;

public class EnemyAreaFollow : MonoBehaviour
{

    public EnemyFollow enemyFollow;
    public void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            enemyFollow.playerInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            enemyFollow.playerInRange = false;
        }
    }
}
