using UnityEngine;

public class Heal : MonoBehaviour
{
    public playerHealth playerHealth;

    public int HealAmount = 4;
    public int HealUses = 4;
    public 

    void Update()
    {

        CallHeal();

    }

    void CallHeal()
    {


        if (Input.GetKeyDown(KeyCode.Q) && HealUses > 0)
        {
            playerHealth.Heal(HealAmount);
            HealUses --;
        }

    }
}
