using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public GameObject attackArea;

    public bool attacking { get; private set; } = false;

    public float timeToAttack = 0.25f;

    private float timer = 0f;
    private Animator animator;

    private void Start()
    {
        attackArea = transform.Find("AttackArea").gameObject;
        animator = GetComponentInChildren<Animator>();

        attackArea.SetActive(false);
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !attacking)
        {
            attacking = true;
            timer = 0f;

            attackArea.SetActive(true);

            // attack 
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);

            animator.SetBool("IsAttacking", true);
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0f;
                attacking = false;

                attackArea.SetActive(false);
                animator.SetBool("IsAttacking", false);
            }
        }
    }
}