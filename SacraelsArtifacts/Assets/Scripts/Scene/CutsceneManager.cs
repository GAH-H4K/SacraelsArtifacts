using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public float cutsceneDuration = 1.8f;
    void Start()
    {
        StartCoroutine(Cutscene());
    }
    
    private IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(cutsceneDuration);
        SceneManager.LoadScene("FirstArea");
    }
}
