using UnityEngine;

public class ParallaxFXYaxl : MonoBehaviour
{
    private float startPosition;
    public GameObject _camera;
    public float parallaxEffecty;
    public void Start()
    {
        startPosition = transform.position.y;

        _camera = GameObject.FindWithTag("MainCamera");
    }

    public void Update()
    {
        float distance = _camera.transform.position.y * parallaxEffecty;

        transform.position = new Vector3(transform.position.x,startPosition + distance , transform.position.z);
    }
}
