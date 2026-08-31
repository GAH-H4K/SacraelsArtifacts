using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTheDemoScreen : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
