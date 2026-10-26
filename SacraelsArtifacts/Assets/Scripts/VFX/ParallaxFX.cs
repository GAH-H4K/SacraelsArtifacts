using UnityEngine;

public class ParallaxFX : MonoBehaviour
{
    private float startPosition;
    public GameObject camera;
    public float parallaxEffect;
    void Start()
    {
        startPosition = transform.position.x;

        camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        float distance = camera.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
    }
}
