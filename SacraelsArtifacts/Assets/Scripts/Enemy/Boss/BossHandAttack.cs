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

    public int HandChoosed = 0;

    public bool Hand1WasChoosed = false;
    public bool Hand2WasChoosed = false;

    public float timeToAttack = 10f;
    public float MaxTimeToAttack = 5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        Hand1.transform.position = Vector2.MoveTowards(
                Hand1.transform.position,
                OriginAttackPoint1.position,
                AttackSpeed * Time.deltaTime);

        Hand2.transform.position = Vector2.MoveTowards(
                Hand2.transform.position,
                OriginAttackPoint2.position,
                AttackSpeed * Time.deltaTime);
        
    }


    void Update()
    {
        TimeToAttack();

        if (Hand1WasChoosed && !isReturning)
        {
            Attack1();
        }

        if (Hand2WasChoosed && !isReturning)
        {
            Attack2();
        }

        if (isReturning)
        {
            BackToOrigin();
        }
    }


    private void Attack1()
    {
        Hand1.transform.position = Vector2.MoveTowards(
            Hand1.transform.position,
            PlayerPosition.position,
            AttackSpeed * Time.deltaTime
        );
    }


    private void Attack2()
    {
        Hand2.transform.position = Vector2.MoveTowards(
            Hand2.transform.position,
            PlayerPosition.position,
            AttackSpeed * Time.deltaTime
        );
    }


    public void BackToOrigin()
    {
        if (Hand1WasChoosed)
        {
            Hand1.transform.position = Vector2.MoveTowards(
                Hand1.transform.position,
                OriginAttackPoint1.position,
                AttackSpeed * Time.deltaTime
            );

            if (Hand1.transform.position == OriginAttackPoint1.position)
            {
                Hand1WasChoosed = false;
                isReturning = false;
            }
        }
        else if (Hand2WasChoosed)
        {
            Hand2.transform.position = Vector2.MoveTowards(
                Hand2.transform.position,
                OriginAttackPoint2.position,
                AttackSpeed * Time.deltaTime
            );

            if (Hand2.transform.position == OriginAttackPoint2.position)
            {
                Hand2WasChoosed = false;
                isReturning = false;
            }
        }
        else if(!Hand1WasChoosed && !Hand2WasChoosed)
        {
            isReturning = false;
        }

    }


    public void AttackActions()
    {
        Debug.Log("funcionaporfavor");

        if (!isReturning)
        {
            HandChoosed = Random.Range(0, 2);

            if (HandChoosed == 0)
            {
                Hand1WasChoosed = true;
            }
            else
            {
                Hand2WasChoosed = true;
            }
        }
    }


    public void TimeToAttack()
    {
        if (timeToAttack > 0)
        {
            timeToAttack -= Time.deltaTime;
        }
        else
        {
            AttackActions();

            timeToAttack = MaxTimeToAttack;
        }
    }

    public void Die()
    {
        animator.SetBool("Die", true);
        Destroy(gameObject, 5f);
    }
}
