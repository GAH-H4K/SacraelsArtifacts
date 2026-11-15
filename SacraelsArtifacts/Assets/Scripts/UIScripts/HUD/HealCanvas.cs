using UnityEngine;
using UnityEngine.UI;

public class HealCanvas : MonoBehaviour
{
    public Heal HealScript;
    public Image[] PotionsImages;
    public int healUsesQuantity;


    void Start()
    {
        healUsesQuantity = HealScript.HealUses;
    }

    public void UpdatePotionsImages()
    {
        healUsesQuantity = HealScript.HealUses;
        for (int i = 0; i < PotionsImages.Length; i++)
        {
            PotionsImages[i].enabled = i < healUsesQuantity;
        }
        Debug.Log("fasfsad");
    }
}
