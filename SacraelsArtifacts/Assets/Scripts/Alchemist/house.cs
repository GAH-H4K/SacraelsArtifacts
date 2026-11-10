using UnityEngine;
using UnityEngine.SceneManagement;

public class house : MonoBehaviour
{
    public GameObject InteractTXT;

    public bool CanEnter;
    
    public string houseSceneName;
    void Update()
    {
        CanEnterHouse();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanEnter = false;
        }
    }

    void CanEnterHouse()
    {
        if(CanEnter)
        {
            InteractTXT.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                EnterHouse();
            }
        }
        else
        {
            InteractTXT.SetActive(false);
        }
    }

    void EnterHouse()
    {
        SceneManager.LoadScene(houseSceneName);
    }
}
