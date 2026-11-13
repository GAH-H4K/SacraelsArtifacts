using Unity.Cinemachine;
using UnityEngine;

public class alchemistDialogue : MonoBehaviour
{
    [Header("Isso aq � o script do trigger")]

    public bool CanTalk = false;
    
    public GameObject CanvasDialogue;

    public GameObject CanvasDialogueNeutral;
    //esse dialogue neutro é oq ele fala quando tu ja fez asmissao ou sla oq;

    public bool firstDialogueHappened;

    public bool playerCanUpgrade;

    //bagalhos pra desativar quando o player tiver trocando ideia

    public playerMovement playerMovement;
    public MeleeAttack playerAttack;
    public Heal playerHeal;//como essa bagaça ja vai ta desativada pro player no incio, quando ele ativar no fim do dialogo ele vai "dar" a cura pra ele(alem de ja n deixar ele se curar enquanto conversam, sou um genio heheheeheheh)
    public GameObject playerCanvas;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerAttack = player.GetComponent<MeleeAttack>();
            playerMovement = player.GetComponent<playerMovement>();
            playerHeal = player.GetComponent<Heal>();
        }
        else
            return;
    }

    void Update()
    {
        if(CanTalk == true && Input.GetKeyDown(KeyCode.E) && !firstDialogueHappened)
        {
            StartFirstDialogue();
        }
        else if(CanTalk == true && Input.GetKeyDown(KeyCode.E) && firstDialogueHappened)
        {
            StartNeutraltDialogue();
        }
    }

    void StartFirstDialogue()
    {
        CanvasDialogue.SetActive(true);


        playerMovement.enabled = false;
        playerAttack.enabled = false;
        playerHeal.enabled = false;
        playerCanvas.SetActive (false);
    }

    void StartNeutraltDialogue()
    {
        CanvasDialogueNeutral.SetActive(true);


        playerMovement.enabled = false;
        playerAttack.enabled = false;
        playerHeal.enabled = false;
        playerCanvas.SetActive(false);
    }

    public void StopDialogue()
    {
        CanvasDialogue.SetActive(false);
        CanvasDialogueNeutral.SetActive(false);

        firstDialogueHappened = true;


        playerMovement.enabled = true;
        playerAttack.enabled = true;
        playerHeal.enabled = true;
        playerCanvas.SetActive(true);

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

            StopDialogue();//acho q n precisa disso mas vai q ne
        }
    }

}
