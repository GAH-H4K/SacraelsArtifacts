using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject FadeOut;

    public GameObject Credits;

    public GameObject GuideText;

    public bool CameraIsUp = true;

    public GameObject Camera;

    public Transform CameraUpPoint;

    public bool CameraIsGoingUp = false;

    public Transform CameraDownPoint;

    public bool CameraIsGoingDown = false;

    public float CameraSpeed = 5f;

    public float ErrorMarginTransform = 0.1f;

    public void Update()
    {
        MoveCamera();

        if (Input.GetKeyDown(KeyCode.Escape) && CameraIsUp == true)
        {
            Application.Quit();
        }

        if (CameraIsGoingDown)
        {
            CameraDown();
        }
        else if (CameraIsGoingUp)
        {
            CameraUp();
        }
    }

    public void MoveCamera()
    {

        if (CameraIsGoingUp == false && CameraIsGoingDown == false)
        {
            if (Input.anyKeyDown && CameraIsUp == true && Input.GetKeyDown(KeyCode.Escape) == false)
            {
                //descer a camera
                CameraIsUp = false;
                CameraIsGoingDown = true;

            }
            else if (Input.GetKeyDown(KeyCode.Escape) && CameraIsUp == false)
            {
                //subir a camera
                CameraIsUp = true;
                CameraIsGoingUp = true;
            }
        }

        
    }

    public void CameraDown()
    {
        GuideText.SetActive(false);

        Camera.transform.position = Vector2.Lerp(
                Camera.transform.position,
                CameraDownPoint.position,
                CameraSpeed * Time.deltaTime);

        if (Camera.transform.position == CameraDownPoint.position)
        {
            CameraIsGoingDown = false;
        }
        else if(Vector2.Distance(Camera.transform.position, CameraDownPoint.transform.position) <= ErrorMarginTransform)
        {
            //margem de erro pra camera e o bglh por caus do lerp
            CameraIsGoingDown = false;
        }
    }

    public void CameraUp()
    {
        GuideText.SetActive(true);

        Camera.transform.position = Vector2.Lerp(
            Camera.transform.position,
            CameraUpPoint.position,
            CameraSpeed * Time.deltaTime);

        if (Camera.transform.position == CameraUpPoint.position)
        {
            CameraIsGoingUp = false;
        }
        else if(Vector2.Distance(Camera.transform.position, CameraUpPoint.transform.position) <= ErrorMarginTransform)
        {
            //margem de erro pra camera e o bglh por caus do lerp
            CameraIsGoingUp = false;
        }
    }

    
    public void GoToGameScene()
    {
        FadeOut.SetActive(true);
        SceneManager.LoadScene("Game");
    }
    public void CreditsOpen()
    {
        Credits.SetActive(true);
    }
    public void CreditsClose()
    {
        Credits.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}


