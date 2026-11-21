using System.Runtime.CompilerServices;
using UnityEngine;

public class BirdsHealth : MonoBehaviour
{
    public BirdsController birdsController;

    public int MaxHealth;
    public int CurrentHealth;

    public GameObject BrokenTree;
    public GameObject Tree;
    void Start()
    {
        Tree.SetActive(true);
        BrokenTree.SetActive(false);
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        birdsController.FlyAway();

        BrokenTree.SetActive(true);
        Tree.SetActive(false);
    }


}
