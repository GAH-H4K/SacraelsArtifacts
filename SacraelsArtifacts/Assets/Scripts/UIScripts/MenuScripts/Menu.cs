using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   


    [Header("Menu UI properties")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        startButton.onClick.AddListener(GoToGameScene);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    private void ExitGame()
    {

    }


}


