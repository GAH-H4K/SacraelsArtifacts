using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;

public class dialogueManager : MonoBehaviour
{
    public GameObject[] Faces;
    public int currentFace = 0;

    public string[] Lines;
    public int currentLine = 0;

    public TMP_Text dialogueText;
    public GameObject background;
    public GameObject dialogueBox;

    public float TypeSpeed;
    private Coroutine TypeTextCoroutine;

    public alchemistDialogue alchemistDialogueScript;


    private void OnEnable()
    {
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Next();
        }
    }

    void StartDialogue()
    {
        TypeTextCoroutine = StartCoroutine(TypeText(Lines[currentLine]));

        foreach (GameObject obj in Faces)
        {
            obj.SetActive(false);
        }

        Faces[currentFace].SetActive(true);
    }
    private void Next()
    {
        if (TypeTextCoroutine != null && currentLine <= Lines.Length)
        {
            StopCoroutine(TypeTextCoroutine);

            dialogueText.text = Lines[currentLine];

            currentLine++;
        }


        if (currentLine >= Lines.Length)
        {
            alchemistDialogueScript.StopDialogue();


            return;
        }

        currentFace++;

        TypeTextCoroutine = StartCoroutine(TypeText(Lines[currentLine]));

        foreach(GameObject obj in Faces)
        {
            obj.SetActive(false);
        }

        Faces[currentFace].SetActive(true);
    }

 

    IEnumerator TypeText(string text)
    {
        dialogueText.text = "";

        foreach(char letter in Lines[currentLine])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(TypeSpeed);
        }
    }

}
