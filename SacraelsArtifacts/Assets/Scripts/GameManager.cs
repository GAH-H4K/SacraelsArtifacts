using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool UnlockedHeal = false;

    public bool DefeteadGolem = false;

    public bool ColetedFirstArtifact;

    public SavePoint savePointScript;

    public Transform SaveTransform;

    public Transform playerTransform;

    public string SaveScene = "";


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
        savePointScript.SavePointScene = scene.name;
    }

    public void BackOnSave()
    {
        GameObject player = GameObject.FindWithTag("Player");
        
        if(player != null)
        {
            playerTransform = player.GetComponent<Transform>();
        }

        playerTransform = SaveTransform;

        SceneManager.LoadScene(SaveScene); 
    }
}
