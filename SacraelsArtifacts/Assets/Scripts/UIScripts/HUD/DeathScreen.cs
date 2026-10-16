using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("FirstScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
