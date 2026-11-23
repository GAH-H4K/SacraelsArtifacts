using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool UnlockedHeal = false;

    public bool DefeteadGolem = false;

    public bool DefeteadBirds = false;

    public bool ColectedFirstArtifact;

    public bool ColectedSecondArtifact;

    public bool ColectedThirdArtifact;

    public SavePoint savePointScript;

    public Transform SaveTransform;

    public Transform playerTransform;

    public string SaveScene = "";


    private void ResetGame()
    {
        ColectedThirdArtifact = false;

        ColectedSecondArtifact = false;

        ColectedFirstArtifact = false;


        UnlockedHeal = false;

        DefeteadGolem = false;

        DefeteadBirds = false;

       
    }
    private void OnEnable()
    {
        ResetGame();
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
        GameObject spawnPointObject = GameObject.FindWithTag("SpawnPoint");

        if(spawnPointObject != null)
        {
            savePointScript = spawnPointObject.GetComponent<SavePoint>();
        }

        savePointScript.SavePointScene = scene.name;
    }

    public void BackOnSave()
    {
        GameObject player = GameObject.FindWithTag("Player");
        
        if(player != null)
        {
            playerTransform = player.GetComponent<Transform>();
        }

        playerTransform.position = SaveTransform.position;

        SceneManager.LoadScene(SaveScene); 
    }
}
