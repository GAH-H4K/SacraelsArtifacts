using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPersistence : MonoBehaviour
{
    public static PlayerPersistence instance;
    public static string spawnName;


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
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(gameObject);
        }
        GameObject spawn = GameObject.Find(spawnName);

        if (spawn != null)
        {
            transform.position = spawn.transform.position;
            spawnName = null;
        }
    }
}
