using System.Runtime.CompilerServices;
using UnityEngine;

public class BirdsHealth : MonoBehaviour
{
    public BirdsController birdsController;

    public GameManager gameManagerScript;

    public int MaxHealth;
    public int CurrentHealth;

    public GameObject BrokenTree;
    public GameObject Tree;

    
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }
        if(gameManagerScript.DefeteadBirds == false)
        {
        Tree.SetActive(true);
        BrokenTree.SetActive(false);
        CurrentHealth = MaxHealth;
     
        }
        else if(gameManagerScript.DefeteadBirds == true)
        {
            BrokenTree.SetActive(false);
        }

    }

    public void TakeDamage(int Damage)
    {
        if(CurrentHealth <= MaxHealth)
        {
             CurrentHealth -= Damage;
        }

        if( CurrentHealth <= 0)
        {
            Die();
        }

       
    }

    private void Die()
    {
        birdsController.FlyAwayCoroutine();

        Tree.SetActive(false);
        BrokenTree.SetActive(true);

        gameManagerScript.DefeteadBirds = true;
    }


}
