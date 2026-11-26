using UnityEngine;
using UnityEngine.SceneManagement;

public class EndeSceneManager : MonoBehaviour
{
    public string sceneName;

    public GameManager gameManagerScript;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && gameManagerScript. ColectedFirstArtifact && gameManagerScript.ColectedSecondArtifact && gameManagerScript.ColectedThirdArtifact)
        {

            SceneManager.LoadScene(sceneName);
        }
        else
        return;
    }
}
