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
        if (Input.GetButtonDown("Fire1") && !CanCombo1 && !CanCombo2)
        {
            StartCoroutine(AttackCombo());
        }
        else if(Input.GetButtonDown("Fire1") && CanCombo1 && !CanCombo2)
        {
            StartCoroutine(AttackCombo1());
        }
        else if(Input.GetButtonDown("Fire1") && !CanCombo1 && CanCombo2)
        {
            AttackCombo2();
        }
    }

    IEnumerator AttackCombo()
    {
        animator.SetTrigger("Attack1");

        CanCombo1 = true;

        yield return new WaitForSeconds(0.5f);

        CanCombo1= false;
    }
    IEnumerator AttackCombo1()
    {
        animator.SetTrigger("Attack2");

        CanCombo2 = true;

        yield return new WaitForSeconds(0.8f);

        CanCombo2 = false;
    }
    private void AttackCombo2()
    {
        animator.SetTrigger("Attack3");
    }


}