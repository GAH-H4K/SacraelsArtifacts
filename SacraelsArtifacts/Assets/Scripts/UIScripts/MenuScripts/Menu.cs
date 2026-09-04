using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject FadeOut;

    public GameObject Credits;

    public void GoToGameScene()
    {
        FadeOut.SetActive(true);
        SceneManager.LoadScene("Game");
    }

    public void CreditsOpen()
    {
        Credits.SetActive(true);
    }
    public void CreditsClose()
    {
        Credits.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}


