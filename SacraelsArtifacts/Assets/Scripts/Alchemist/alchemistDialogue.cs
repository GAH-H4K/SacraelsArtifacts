using Unity.Cinemachine;
using UnityEngine;

public class alchemistDialogue : MonoBehaviour
{
    [Header("Isso aq � o script do trigger")]

    public bool CanTalk = false;
    
    public GameObject CanvasDialogue;
    void Update()
    {
        if(CanTalk == true && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        CanvasDialogue.SetActive(true);
    }

    public void StopDialogue()
    {
        CanvasDialogue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanTalk = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanTalk = false;
        }
    }

}
