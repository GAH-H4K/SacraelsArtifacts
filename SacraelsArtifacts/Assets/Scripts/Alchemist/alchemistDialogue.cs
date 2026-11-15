using Unity.Cinemachine;
using UnityEngine;

public class alchemistDialogue : MonoBehaviour
{
    [Header("Isso aq � o script do trigger")]

    public bool CanTalk = false;
    
    public GameObject CanvasDialogue;

    public GameObject InteractTXT;

    public GameObject CanvasDialogueNeutral;
    //esse dialogue neutro é oq ele fala quando tu ja fez asmissao ou sla oq;

    public bool playerCanUpgrade;

    //bagalhos pra desativar quando o player tiver trocando ideia

    public playerMovement playerMovement;
    public MeleeAttack playerAttack;
    public Heal playerHeal;//como essa bagaça ja vai ta desativada pro player no incio, quando ele ativar no fim do dialogo ele vai "dar" a cura pra ele(alem de ja n deixar ele se curar enquanto conversam, sou um genio heheheeheheh)
    public GameObject playerCanvas;

    //bagalho pra resetar

    public dialogueManager dialogueManager;

    public GameManager gameManagerScript;

    private void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");

        if(gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }

        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerAttack = player.GetComponent<MeleeAttack>();
            playerMovement = player.GetComponent<playerMovement>();
            playerHeal = player.GetComponent<Heal>();
            playerCanvas = GameObject.FindWithTag("PlayerCanvas");
        }
        else
            return;
    }

    void Update()
    {
        if(CanTalk == true && Input.GetKeyDown(KeyCode.E) && gameManagerScript.UnlockedHeal == false)
        {
            StartFirstDialogue();
        }
        else if(CanTalk == true && Input.GetKeyDown(KeyCode.E) && gameManagerScript.UnlockedHeal == true)
        {
            StartNeutraltDialogue();
        }
    }

    void StartFirstDialogue()
    {
        CanvasDialogue.SetActive(true);


        playerMovement.StopMoving();
        playerMovement.enabled = false;
        playerAttack.enabled = false;
        playerHeal.enabled = false;
       
        playerCanvas.SetActive (false);
    }

    void StartNeutraltDialogue()
    {
        dialogueManager.currentLine = 0;
        dialogueManager.currentFace = 0;


        CanvasDialogueNeutral.SetActive(true);

        playerMovement.StopMoving();
        playerMovement.enabled = false;
        playerAttack.enabled = false;
        playerHeal.enabled = false;
        playerCanvas.SetActive(false);
    }

    public void StopDialogue()
    {
        CanvasDialogue.SetActive(false);
        CanvasDialogueNeutral.SetActive(false);

        


        playerMovement.StartMoving();
        playerMovement.enabled = true;
        playerAttack.enabled = true;
        playerHeal.enabled = true;
        playerCanvas.SetActive(true);

        gameManagerScript.UnlockedHeal = true;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanTalk = true;

            InteractTXT.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanTalk = false;

            InteractTXT.SetActive(false);

        }
    }

}
