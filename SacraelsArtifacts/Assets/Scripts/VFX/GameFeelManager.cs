using UnityEngine;
using System.Collections;

public class GameFeelManager : MonoBehaviour
{
    public static GameFeelManager Instance;
    private Coroutine HitStopCoroutine;


    private void Awake()
    {
        Instance = this;
    }

    public void HitStop(float duration)
    {
        if (HitStopCoroutine != null)
        {
            StopCoroutine(HitStopCoroutine);
        }
        HitStopCoroutine = StartCoroutine(HitStopCoroutineRoutine(duration));
    }

    private IEnumerator HitStopCoroutineRoutine(float duration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
        HitStopCoroutine = null;
    }
}
