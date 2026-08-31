using UnityEngine;

public class FadeInGame : MonoBehaviour
{
    public GameObject Fade;
    public void Start()
    {
        Fade.SetActive(true);
        Destroy(gameObject, 3f);
    }

    
}
