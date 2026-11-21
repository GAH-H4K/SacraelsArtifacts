using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class BirdsController : MonoBehaviour
{
    public Animator animator;

    public GameObject[] FeathersSpawners;

    public bool CanChooseAttack = true;

    [Header("CooldownsInsanos")]

    public float AerialAttackTimer;

    public float DashAttackTimer;

    public float IdleAttackCooldown;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(CanChooseAttack)
        {
            ChooseAttack();
        }
    }


    public void ChooseAttack()
    {
        CanChooseAttack = false;

        for(int i = 0; i < FeathersSpawners.Length; i++)
        {
            FeathersSpawners[i].SetActive(false);

            Debug.Log(i);
        }

      

        int ChoosedAttack = Random.Range(0, 3);

        Debug.Log(ChoosedAttack);

        if (ChoosedAttack == 0)
        {
            callAerialAttack();
        }
        else if(ChoosedAttack == 1)
        {
            StartCoroutine(DashAttack());
        }
        else if(ChoosedAttack == 2)
        {
            StartCoroutine(IdleAttack());
        }
        
    }

    public IEnumerator IdleAttack()
    {

        animator.SetBool("Idle", true);
       
        FeathersSpawners[1].SetActive(true);

        yield return new WaitForSeconds(IdleAttackCooldown);

        animator.SetBool("Idle", false);

        CanChooseAttack = true;
        Debug.Log("dile");
    }


    public void callAerialAttack()
    {
        StartCoroutine(AerialAttack());
    }

    private IEnumerator AerialAttack()
    {
        Debug.Log("ar");
        animator.SetBool("AerialAttack", true);

        FeathersSpawners[2].SetActive(true);

        yield return new WaitForSeconds(AerialAttackTimer);

        animator.SetBool("AerialAttack", false);

        CanChooseAttack = true;

    }
    public IEnumerator DashAttack()
    {
        animator.SetTrigger("DashAttack");

        Debug.Log("dasg");

        yield return new WaitForSeconds(DashAttackTimer);

        CanChooseAttack = true;
    }
}
