using UnityEngine;

public class Artifact1 : MonoBehaviour
{
    public GameManager gameManagerScript;

    public bool CanCollect = false;

    public GameObject InteractTxt;


    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }

        if (gameManagerScript.ColectedSecondArtifact == true)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(CanCollect == true)
        {
            VerifyCollect();
        }
    }

    public void VerifyCollect()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
    }

    public void Collect()
    {
        gameManagerScript.ColectedSecondArtifact = true;
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanCollect = true;

            InteractTxt.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanCollect = false;

            InteractTxt.SetActive(false);
        }
    }
}
