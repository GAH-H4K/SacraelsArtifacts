using UnityEngine;
public class MeleeAttack : MonoBehaviour
{
    private GameObject attackArea;

    private bool attacking = false;

    private float timeToAttack = 0.25f;

    private float timer = 0f;
    private Animator animator;


    private void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
