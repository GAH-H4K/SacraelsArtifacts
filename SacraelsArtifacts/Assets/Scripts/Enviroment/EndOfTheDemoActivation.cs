using UnityEngine;

public class EndOfTheDemoActivation : MonoBehaviour
{
    public GameObject EndOfDemoCanvas;
    public playerMovement _playerMovement;
    public MeleeAttack meleeAttack;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        EndOfDemoCanvas.SetActive(true);
        _playerMovement.enabled = false;
        meleeAttack.enabled = false;
    }
}
