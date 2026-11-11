using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{

    public bool attacking { get; private set; } = false;

    public bool CanCombo1 = false;

    public bool CanCombo2 = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
        {
            if (!CanCombo1 && !CanCombo2)
            {
                StartCoroutine(AttackCombo());
            }
            else if (CanCombo1 && !CanCombo2)
            {
                StartCoroutine(AttackCombo1());
            }
            else if (!CanCombo1 && CanCombo2)
            {
                AttackCombo2();
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator AttackCombo()
    {
        animator.SetTrigger("Attack1");

        CanCombo1 = true;

        yield return new WaitForSeconds(0.3f);

        CanCombo1= false;
    }
    IEnumerator AttackCombo1()
    {
        animator.SetTrigger("Attack2");

        CanCombo2 = true;

        yield return new WaitForSeconds(0.3f);

        CanCombo2 = false;
    }
    private void AttackCombo2()
    {
        animator.SetTrigger("Attack3");
    }


}