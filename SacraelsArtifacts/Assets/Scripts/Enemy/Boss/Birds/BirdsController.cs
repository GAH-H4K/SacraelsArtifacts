using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class BirdsController : MonoBehaviour
{
    public GameManager gameManagerScript;
    public Animator animator;

    public GameObject[] FeathersSpawners;

    public GameObject limitsColliders;

    public bool CanChooseAttack = true;

    public bool BossFightStarted = false;

    public bool BossFightIsOver = false;

    [Header("CooldownsInsanos")]

    public float AerialAttackTimer;

    public float DashAttackTimer;

    public float IdleAttackCooldown;


    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }

        if (gameManagerScript.DefeteadBirds == true)
        {
            Destroy(gameObject);
        }

        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (CanChooseAttack && BossFightStarted && BossFightIsOver == false)
        {
            ChooseAttack();
        }
    }


    public void ChooseAttack()
    {
        CanChooseAttack = false;

        for (int i = 0; i < FeathersSpawners.Length; i++)
        {
            FeathersSpawners[i].SetActive(false);
        }



        int ChoosedAttack = Random.Range(0, 3);

        Debug.Log(ChoosedAttack);

        if (ChoosedAttack == 0)
        {
            callAerialAttack();
        }
        else if (ChoosedAttack == 1)
        {
            StartCoroutine(DashAttack());
        }
        else if (ChoosedAttack == 2)
        {
            StartCoroutine(IdleAttack());
        }

    }

    public IEnumerator IdleAttack()
    {

        animator.SetBool("Idle", true);

        FeathersSpawners[0].SetActive(true);

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

        FeathersSpawners[1].SetActive(true);

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
    public void FlyAwayCoroutine()
    {
        limitsColliders.SetActive(false);

        StartCoroutine(FlyAway());
    }

    public IEnumerator FlyAway()
    {

        for (int i = 0; i < FeathersSpawners.Length; i++)
        {
            FeathersSpawners[i].SetActive(false);
        }

        BossFightIsOver = true;

        animator.SetTrigger("Defeat");

        yield return new WaitForSeconds(10);

        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!BossFightStarted)
        {
            StartCoroutine(StartBossFight());
        }  
    }

    public IEnumerator StartBossFight()
    {
        animator.SetBool("StartBossFight", true);

        limitsColliders.SetActive(true);

        yield return new WaitForSeconds(5);

        BossFightStarted = true;
    }
}
