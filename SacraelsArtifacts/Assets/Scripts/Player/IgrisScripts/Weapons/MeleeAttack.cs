using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{
    public GameObject attackArea;

    public bool attacking { get; private set; } = false;

    public float timeToAttack = 0.6f;

    public float timeToActivateAttackArea = 0.2f;


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

            animator.SetBool("IsAttacking", true);

            StartCoroutine(SetAttackAreaActive());
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0f;
                attacking = false;
                animator.SetBool("IsAttacking", false);
            }
        }
    }

    IEnumerator SetAttackAreaActive()
    {
        attackArea.SetActive(true);

        yield return new WaitForSeconds(timeToActivateAttackArea);

        attackArea.SetActive(false);
    }
    
}