using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private int health;
    public int MaxHealth = 200;
    public int secondPhaseHealth = 100;
    public DamagedParticle damagedParticle;
    private Animator animator;
    public GameObject BossArmored;
    public GameObject BossExpost;

    public BossHandAttack BossHands;

    public bool isArmored = true;

    private int currentParticle = 0;

    public BossActivation BossActivation;

    public Transform particleSpawnPoint;

    void Start()
    {
        BossHands = GetComponentInChildren<BossHandAttack>();
        health = MaxHealth;
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

        if (health <= secondPhaseHealth && isArmored == true)
        {
            changeParticle();
            BossArmored.SetActive(false);
            BossExpost.SetActive(true);
            isArmored = false;

        }
    }
    public void Die()
    {
        BossHands.Die();
        BossActivation.OpenBossFightConfiner();
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
