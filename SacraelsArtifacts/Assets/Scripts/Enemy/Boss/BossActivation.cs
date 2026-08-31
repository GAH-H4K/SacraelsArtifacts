using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossFight;
    public GameObject bossConfiner;
    public bool ifAlredyExecuted = false;
    public void OpenBossFightConfiner()
    {
        bossConfiner.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ifAlredyExecuted == false )
        {
            bossFight.SetActive(true);
            ifAlredyExecuted = true;
            bossConfiner.SetActive(true);
        }

    }

}
