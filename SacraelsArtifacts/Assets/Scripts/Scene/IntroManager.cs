using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject[] introText;
    public GameObject introCanvas;
    public GameObject guideCanvas;
    public int currentText;

    public bool CanGoToNext = true;

    public bool playableSceneIsOn = true;

    public Animator animator;

    public float TextTime;

    void Start()
    {
        animator.SetBool("Idle", true);
    }

    void Update()
    {
        Intro();

        if(playableSceneIsOn)
        {
            guideCanvas.SetActive(true);
        }
        else if(!playableSceneIsOn)
        {
            guideCanvas.SetActive(false);
        }
    }

    public void Intro()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && CanGoToNext && !playableSceneIsOn)
        {
            StartCoroutine(NextCanvas());
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && CanGoToNext && playableSceneIsOn)
        {
            StartCoroutine(Shake());
        }
    }

    private IEnumerator NextCanvas()
    {
        if(currentText >= introText.Length)
        {
            SceneManager.LoadScene("cutsceneintroduction");
        }
        else if (currentText <= introText.Length)
        {
            introCanvas.SetActive(true);

            CanGoToNext = false;

            introText[currentText].SetActive(true);

            yield return new WaitForSeconds(TextTime);

            introText[currentText].SetActive(false);

            introCanvas.SetActive(false);

            playableSceneIsOn = true;

            CanGoToNext = true;

            currentText++;

        }
    }

    private void ShakeAnim()
    {
        animator.SetTrigger("Shake");
    }

    private IEnumerator Shake()
    {
        ShakeAnim();
        yield return new WaitForSeconds(2f);
        playableSceneIsOn = false;
    }


}
