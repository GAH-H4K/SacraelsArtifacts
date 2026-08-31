using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossFightConfiner;

    public GameObject boss;

    public bool isBossFightActive = false;

    public bool ifAlredyExecuted = false;



    private void Update()
    {
        if(isBossFightActive == false)
        {
            bossFightConfiner.SetActive(false);
            boss.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ifAlredyExecuted == false )
        {
            bossFightConfiner.SetActive(true);
            boss.SetActive(true);
            ifAlredyExecuted = true;
            isBossFightActive = true;
        }

    }
}
