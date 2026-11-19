using UnityEngine;
using UnityEngine.SceneManagement;
public class SavePoint : MonoBehaviour
{
    public Transform SavePointTransform;

    public string SavePointScene;

    public GameManager gameManagerScript;

    public bool CanSave = false;

    public GameObject InteractTxt;
    
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if(gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }

        Vector3 SavePointTransform = transform.position;
    }


    public void SaveSpawnPos()
    {
        SavePointTransform = gameManagerScript.SaveTransform;

        SavePointScene = SceneManager.GetActiveScene().name;

        Debug.Log(SavePointScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanSave = true;
            InteractTxt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanSave = false;
            InteractTxt.SetActive(false);
        }
    }
}
