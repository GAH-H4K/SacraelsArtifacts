using UnityEngine;
public class MeleeAttack : MonoBehaviour
{
    public GameObject attackArea;

    private bool attacking = false;

    public float timeToAttack = 0.25f;

    public float timer = 0.5f;
    private Animator animator;


    private void Start()
    {
        attackArea = transform.Find("AttackArea").gameObject;
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            attacking = true;
            attackArea.SetActive(attacking);
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

    
}
