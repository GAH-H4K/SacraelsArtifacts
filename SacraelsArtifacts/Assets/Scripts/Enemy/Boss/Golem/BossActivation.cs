using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossFight;
    
    public GameObject bossConfiner;

    private bool ifAlredyExecuted = false;

    public GameManager gameManagerScript;

    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }
    }
    public void OpenBossFightConfiner()
    {
        bossConfiner.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ifAlredyExecuted == false && gameManagerScript.DefeteadGolem == false)
        {
            bossFight.SetActive(true);
            ifAlredyExecuted = true;
            bossConfiner.SetActive(true);
        }
        else
            return;

    }

}
