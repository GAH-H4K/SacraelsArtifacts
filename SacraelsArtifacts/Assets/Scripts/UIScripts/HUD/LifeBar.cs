using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image LifeBarIMG;

    public playerHealth playerHealth;

    public int Flashes = 2;

    public float FillSpeed = 4;

  
    void Update()
    {
        if (playerHealth != null)
        {
          float LifeBarFillAmount = (float)playerHealth.health / playerHealth._healthMax;

            LifeBarIMG.fillAmount = Mathf.Lerp(LifeBarIMG.fillAmount, LifeBarFillAmount, Time.deltaTime * FillSpeed);
        }
    }

    public IEnumerator Flash()
    {
        for (int i = 0; i < Flashes; i++)
        {
            LifeBarIMG.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            LifeBarIMG.color = new Color(0.5f, 0, 0, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
