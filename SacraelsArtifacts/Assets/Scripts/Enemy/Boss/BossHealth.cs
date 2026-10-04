using UnityEngine;
using System.Collections;

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

    private SpriteRenderer spriteRend;

    public int flashCount = 0;

    void Start()
    {
        BossHands = GetComponentInChildren<BossHandAttack>();

        health = MaxHealth;

        animator = GetComponentInChildren<Animator>();

        GetSpriteRenderer();

        BossArmored.SetActive(true);

        BossExpost.SetActive(false);
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(FlashSprite());

        Instantiate(damagedParticle.particlePrefab[currentParticle], particleSpawnPoint.position, Quaternion.identity);

        health -= damage;

        if (health <= 0)
        {
            Die();
        }

        if (health <= secondPhaseHealth && isArmored == true)
        {

            BossArmored.SetActive(false);

            BossExpost.SetActive(true);

            GetSpriteRenderer();

            isArmored = false;
            
            changeParticle();
        }
    }

    private IEnumerator FlashSprite()
    {

        for (int i = 0; i < flashCount; i++)
        {
            spriteRend.color = new Color(1, 0.9f, 0.9f, 1);

            yield return new WaitForSeconds(0.1f);

            spriteRend.color = new Color(1, 1, 1, 1);
        }


    }
    public void Die()
    {
        BossHands.Die();
        BossActivation.OpenBossFightConfiner();
        animator.SetBool("BossDie", true);
        Destroy(gameObject, 10f);
    }

    private void GetSpriteRenderer()
    {
        spriteRend = GetComponentInChildren<SpriteRenderer>();
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
