using UnityEngine;

public class Alchemist : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collider.CompareTag("player") && Input.GetKeyDown(KeyCode.E));
        {
            
        }
    }

    private void StartDialogue()
    {
        
    }
}
