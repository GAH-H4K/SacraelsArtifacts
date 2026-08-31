using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 100;
    public DamagedParticle damagedParticle;
    private Animator animator;
    public GameObject BossArmored;
    public GameObject BossExpost;

    public bool isArmored = true;

    private int currentParticle = 0;

    public Transform particleSpawnPoint;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        BossArmored.SetActive(true);
        BossExpost.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(damagedParticle.particlePrefab[currentParticle], particleSpawnPoint.position, Quaternion.identity);
        
        if (health <= 0)
        {
            Die();
        }

        if (health <= 50 && isArmored == true)
        {
            changeParticle();
            BossArmored.SetActive(false);
            BossExpost.SetActive(true);
            isArmored = false;

        }



    }
    public void Die()
    {
        animator.SetBool("BossDie", true);
        Destroy(gameObject, 10f);


    }

    void changeParticle()
    {
        currentParticle++;
        if (currentParticle >= damagedParticle.particlePrefab.Length)
        {
            currentParticle = 0;
        }
    }
}
