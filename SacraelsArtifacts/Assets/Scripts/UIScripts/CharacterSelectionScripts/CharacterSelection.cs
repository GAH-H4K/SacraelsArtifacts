using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
     public GameObject[] backgrounds;   // As imagens dos personagens
    public string[] characterNames;    // Nome de cada personagem
    public TMP_Text nameText;

    private int selectedCharacter = 0;

    void Start()
    {
        UpdateCharacter();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
           NextCharacter();
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
           PreviousCharacter();
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    void UpdateCharacter()
    {
        for (int i = 0; i < backgrounds.Length; i++)
            backgrounds[i].SetActive(i == selectedCharacter);

        nameText.text = characterNames[selectedCharacter];
    }

    public void NextCharacter()
    {
        selectedCharacter = (selectedCharacter + 1) % backgrounds.Length;
        UpdateCharacter();
    }

    public void PreviousCharacter()
    {
        selectedCharacter = (selectedCharacter - 1 + backgrounds.Length) % backgrounds.Length;
            UpdateCharacter();
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
            SceneManager.LoadScene("Game");
    }
}
