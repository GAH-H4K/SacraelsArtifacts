using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public GameObject FadeOut = null;

    public GameObject Credits;

    public GameObject GuideText;

    public GameObject Options;

    [Header("Camera Settings")]

    public bool CameraIsUp = true;

    public GameObject Camera;

    public Camera cameraComponent;

    public Transform CameraUpPoint;

    public bool CameraIsGoingUp = false;

    public Transform CameraDownPoint;

    public bool CameraIsGoingDown = false;

    public float CameraSpeed = 5f;

    public float ErrorMarginTransform = 0.1f;

    [Header("Selection Star Settings")]

    public Transform SelectionStar;

    public RectTransform[] Buttons;

    public float SelectionStarSpeed = 5f;

    public int CurrentButtonIndex = 0;

    public float SelectionStarDistanceFromButton = 1f;

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

        //fechar a tela de creditos com esc
        if (Input.GetKeyDown(KeyCode.Escape) && Credits.activeSelf == true)
        {
            CreditsClose();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && Options.activeSelf == true)
        {
            CloseOptions();
        }
        

        //mexer a estrela de selecao
        if (CameraIsUp == false && CameraIsGoingDown == false && CameraIsGoingUp == false)
        {
            SelectButton();

            Vector3[] corners = new Vector3[4];

            Buttons[CurrentButtonIndex].GetWorldCorners(corners);

            Vector3 buttonPosition = (corners[0] + corners[1]) / 2f;

            buttonPosition.x -= SelectionStarDistanceFromButton;
            buttonPosition.z = SelectionStar.transform.position.z;

            SelectionStar.transform.position = Vector3.Lerp(
                SelectionStar.transform.position,
                buttonPosition,
                SelectionStarSpeed * Time.deltaTime);


            for (int i = 0; i < Buttons.Length; i++)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(
                    Buttons[i],
                    Input.mousePosition,
                    cameraComponent))
                {
                    CurrentButtonIndex = i;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Buttons[CurrentButtonIndex].GetComponent<Button>().onClick.Invoke();
            }

        }
    }

    public void SelectButton()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            CurrentButtonIndex++;
            if (CurrentButtonIndex >= Buttons.Length)
            {
                CurrentButtonIndex = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            CurrentButtonIndex--;
            if (CurrentButtonIndex < 0)
            {
                CurrentButtonIndex = Buttons.Length - 1;
            }
        }
    }

    public void MoveCamera()
    {

        if (CameraIsGoingUp == false && CameraIsGoingDown == false && Credits.activeSelf == false && Options.activeSelf == false)
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
        else if (Vector2.Distance(Camera.transform.position, CameraDownPoint.transform.position) <= ErrorMarginTransform)
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
        else if (Vector2.Distance(Camera.transform.position, CameraUpPoint.transform.position) <= ErrorMarginTransform)
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

    public void OpenOptions()
    {
        Options.SetActive(true);
    }

    public void CloseOptions()
    {
        Options.SetActive(false);
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


