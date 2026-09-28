using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuCanvas;

    public bool IsPaused = false;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)  && IsPaused == false)
        {
            Time.timeScale = 0;

            IsPaused = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)  && IsPaused == true)
        {
            Time.timeScale = 1;

            IsPaused = false;
        }
    }


}
