using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossFightConfiner;

    public GameObject boss;

    public bool isBossFightActive = false;

    public bool ifAlredyExecuted = false;

    public float TimeToFinishTheFight = 10f;//isso é o tempo pra desativar o garotao



    private void Update()
    {
        timeToFinishTheFight();
        IsFightOver();
    }

    public void timeToFinishTheFight()
    {
        if(TimeToFinishTheFight > 0 && isBossFightActive == false)
        {
           TimeToFinishTheFight -= Time.deltaTime;
        }
       
    }

    public void IsFightOver()
    {
        if(isBossFightActive == false && TimeToFinishTheFight <= 0)
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
