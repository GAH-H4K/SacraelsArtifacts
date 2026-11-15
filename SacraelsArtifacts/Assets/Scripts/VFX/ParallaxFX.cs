using UnityEngine;

public class ParallaxFX : MonoBehaviour
{
    private float startPosition;
    public GameObject _camera;
    public float parallaxEffect;
    void Start()
    {
        startPosition = transform.position.x;

        _camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        float distance = _camera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
    }
}
