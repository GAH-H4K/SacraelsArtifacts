using UnityEngine;
using UnityEngine.SceneManagement;
public class SavePoint : MonoBehaviour
{
    public Transform SavePointTransform;

    public string SavePointScene;

    public Save saveScript;
    
    void Start()
    {
        Vector3 SavePointTransform = transform.position;
    }

    public void SaveSpawnPos()
    {
        
    }
}
