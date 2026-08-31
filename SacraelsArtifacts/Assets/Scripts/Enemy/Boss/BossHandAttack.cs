using UnityEngine;

public class BossHandAttack : MonoBehaviour
{
    public GameObject Hand1;

    public GameObject Hand2;

    public float AttackSpeed = 5f;

    public Transform OriginAttackPoint1;

    public Transform OriginAttackPoint2;

    public Transform PlayerPosition;

    public bool isReturning = false;

    public bool Hand1IsAttacking = false;

    public bool Hand2IsAttacking = false;

    void Start()
    {
        BackToOrigin();
    }

    
    public void Update()
    {
        if( isReturning == false)
        {
            Attack();
        }
        else
        {
            BackToOrigin();
        }
    }

    private void Attack()
    {
        Hand1.transform.position = Vector2.MoveTowards(Hand1.transform.position, PlayerPosition.position, AttackSpeed * Time.deltaTime);
    }

    public void BackToOrigin()
    {
        Hand1.transform.position = Vector2.MoveTowards(Hand1.transform.position, OriginAttackPoint1.position, AttackSpeed * Time.deltaTime);
        
        if(Hand1.transform.position == OriginAttackPoint1.position)
        {
            isReturning = false;
        }
    }
}
