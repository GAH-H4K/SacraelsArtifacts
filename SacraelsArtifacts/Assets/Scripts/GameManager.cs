using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool UnlockedHeal = false;

    public bool DefeteadGolem = false;

    private void OnEnable()
    {
       UnlockedHeal = false;

       DefeteadGolem = false;
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
    }
}
