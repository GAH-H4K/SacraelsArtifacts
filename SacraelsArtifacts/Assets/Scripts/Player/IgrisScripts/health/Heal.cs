using System.Collections;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public playerHealth playerHealth;

    public int HealAmount = 4;
    public int HealUses = 4;
    public float CooldownToHeal = 2f;
    public bool CanHeal = true;

    public void Update()
    {

        CallHeal();

    }

    void CallHeal()
    {


        if (Input.GetKeyDown(KeyCode.Q) && HealUses > 0) 
        {
            if (CanHeal == true && playerHealth.health > playerHealth._healthMax)
            {
                StartCoroutine(HealCooldown());
            }
        }

    }

    private IEnumerator HealCooldown()
    {
        CanHeal = false;

        playerHealth.Heal(HealAmount);

        HealUses--;

        yield return new WaitForSeconds(CooldownToHeal);

        CanHeal = true;
    }
}
