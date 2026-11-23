using System.Runtime.CompilerServices;
using UnityEngine;

public class BirdsHealth : MonoBehaviour
{
    public BirdsController birdsController;

    public GameManager gameManagerScript;
    public DamagedParticle damagedParticleScript;

    public Animator TreeAnimator;

    public bool Died = false;

    public int MaxHealth;
    public int CurrentHealth;

    public GameObject BrokenTree;
    public GameObject Tree;

    public GameObject BossFightConfiner;

    public Transform particlesSpawnPoint;



    void Start()
    {

        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }
        if(gameManagerScript.DefeteadBirds == false)
        {
        TreeAnimator = GetComponent<Animator>();
        Tree.SetActive(true);
        BrokenTree.SetActive(false);
        CurrentHealth = MaxHealth;
     
        }
        else if(gameManagerScript.DefeteadBirds == true)
        {
            BrokenTree.SetActive(true);
            Tree.SetActive(false);
        }

    }

    public void TakeDamage(int Damage)
    {
        TreeAnimator.SetTrigger("GotHit");
        damagedParticleScript.SpawnParticle(particlesSpawnPoint.position);
        if(CurrentHealth <= MaxHealth)
        {
             CurrentHealth -= Damage;
        }

        if (CurrentHealth <= 0 && Died == false)
        {
            Die();
        }
        else
            return;

       
    }

    private void Die()
    {
        Died = true;

        BossFightConfiner.SetActive(false);

        birdsController.FlyAwayCoroutine();

        Tree.SetActive(false);
        BrokenTree.SetActive(true);

        gameManagerScript.DefeteadBirds = true;
    }


}
