using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CameraPersistence : MonoBehaviour
{
    public static CameraPersistence instance;
    private CinemachineConfiner2D confiner2D;
    public Collider2D bounds;
    CinemachineCamera CineCam;
    


    void Awake()
    {
        CineCam = GetComponent<CinemachineCamera>();


        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateCameraBounds(bounds);
        UpdateCameraScale();
    }

    public void UpdateCameraScale()
    {
        Camera mainCam = Camera.main;

        CineCam.Lens.OrthographicSize = mainCam.orthographicSize;

    }

    public void UpdateCameraBounds(Collider2D newBounds)
    {
        GameObject boundsObject = GameObject.FindWithTag("CameraBounds");

        if (boundsObject == null)
        {
            Destroy(gameObject);
            Debug.Log("n tem beirada pra camera seu bobao");
        }

        if (confiner2D == null)
        {
            confiner2D = GetComponent<CinemachineConfiner2D>();
        }

        if(confiner2D != null)
        {
            confiner2D.BoundingShape2D = boundsObject.GetComponent<Collider2D>();

            confiner2D.InvalidateBoundingShapeCache();
        }


    }
}
