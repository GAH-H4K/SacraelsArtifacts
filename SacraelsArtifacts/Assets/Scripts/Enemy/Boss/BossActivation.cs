using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject bossFightConfiner;

    public GameObject boss;

    public bool isBossFightActive = false;

    void Start()
    {
        bossFightConfiner.SetActive(false);
        boss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossFightConfiner.SetActive(true);
            boss.SetActive(true);
        }

        isBossFightActive = true;
    }
}
