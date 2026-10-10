using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image LifeBarIMG;

    public playerHealth playerHealth;

    public float FillSpeed = 4;

  
    void Update()
    {
        if (playerHealth != null)
        {
          float LifeBarFillAmount = (float)playerHealth.health / playerHealth._healthMax;

            LifeBarIMG.fillAmount = Mathf.Lerp(LifeBarIMG.fillAmount, LifeBarFillAmount, Time.deltaTime * FillSpeed);
        }
    }
}
