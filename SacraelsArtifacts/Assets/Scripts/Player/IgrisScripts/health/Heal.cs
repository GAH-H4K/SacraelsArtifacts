using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public playerHealth playerHealth;

    public int HealAmount = 4;
    public int HealUses = 4;
    public float CooldownToHeal = 2f;
    public bool CanHeal = true;

    public GameObject PotionsCanvas;
    public HealCanvas PotionsCanvasScript;
    public LifeBar lifeBar;


    public void Update()
    {

        CallHeal();

    }

    private void OnEnable()
    {
        PotionsCanvas.SetActive(true);
    }

    void CallHeal()
    {


        if (Input.GetKeyDown(KeyCode.Q) && HealUses > 0) 
        {
            if (CanHeal == true && playerHealth.health < playerHealth._healthMax)
            {

                StartCoroutine(HealCooldown());
                lifeBar.StartCoroutine(lifeBar.Flash());
            }
        }

        

    }

    private IEnumerator HealCooldown()
    {
        CanHeal = false;

        playerHealth.Heal(HealAmount);

        HealUses--;

        PotionsCanvasScript.UpdatePotionsImages();

        yield return new WaitForSeconds(CooldownToHeal);

        CanHeal = true;
    }
}
