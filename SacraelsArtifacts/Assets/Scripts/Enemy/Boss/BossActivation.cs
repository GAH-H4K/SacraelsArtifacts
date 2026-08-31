using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossFight;


    public bool isBossFightActive = false;

    public bool ifAlredyExecuted = false;

    public float TimeToFinishTheFight = 10f;//isso é o tempo pra desativar o garotao

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ifAlredyExecuted == false )
        {
            bossFight.SetActive(true);
            ifAlredyExecuted = true;
            isBossFightActive = true;
        }

    }

}
