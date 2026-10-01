using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuCanvas;

    public playerMovement _playerMovement;

    public MeleeAttack meleeAttack;

    public bool IsPaused = false;

    public bool CanPause = true;


    public void Update()
    {
        if(CanPause == true)
        {
          Pause();
        }
        
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == true)
            {

                //DESPAUSADO
                Time.timeScale = 1.0f;

                IsPaused = false;

                Debug.Log("despausou");

                _playerMovement.enabled = true;

                meleeAttack.enabled = true;

                PauseMenuCanvas.SetActive(false);
                
            }
            else if (IsPaused == false)
            {

                //PAUSADO
                Time.timeScale = 0f;

                IsPaused = true;

                Debug.Log("pausou");

                _playerMovement.enabled = false;

                meleeAttack.enabled = false;

                PauseMenuCanvas.SetActive(true);
            }
        }
    }


}
