using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool UnlockedHeal = false;

    public bool DefeteadGolem = false;

    public bool ColetedFirstArtifact;

    public SavePoint savePointScript;

    private void OnEnable()
    {
       ColetedFirstArtifact = false;

       UnlockedHeal = false;

       DefeteadGolem = false;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("balls");

        savePointScript.SavePointScene = scene.name;
    }
}
