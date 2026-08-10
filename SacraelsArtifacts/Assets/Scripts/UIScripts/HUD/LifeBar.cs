using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
     public Image LifeBarIMG;

    public playerHealth playerHealth;
  
    void Update()
    {
        if (playerHealth != null)
        {
          LifeBarIMG.fillAmount = playerHealth.health / playerHealth._healthMax;
        }
    }
}
