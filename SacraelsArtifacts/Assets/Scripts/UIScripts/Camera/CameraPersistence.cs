using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;

public class CameraPersistence : MonoBehaviour
{
    public static CameraPersistence instance;
    private CinemachineConfiner2D confiner2D;
    public Collider2D bounds;


    void Awake()
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
        UpdateCameraBounds(bounds);
    }

    public void UpdateCameraBounds(Collider2D newBounds)
    {
        GameObject boundsObject = GameObject.FindWithTag("CameraBounds");

        if (confiner2D == null)
        {
            confiner2D = GetComponent<CinemachineConfiner2D>();
        }

        confiner2D.BoundingShape2D = boundsObject.GetComponent<Collider2D>();

        
        confiner2D.InvalidateBoundingShapeCache(); 

    }
}
