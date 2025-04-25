using UnityEngine;
using TMPro;

public class NPCHandler : MonoBehaviour
{
    [Header("NPC Info")]
    public string npcName;
    public string backstory;

    [Header("UI")]
    public GameObject interactHint;
    public GameObject dialogueHolder;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueBox;

    private bool canInteract = false;

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
        interactHint.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
        interactHint.SetActive(false);
    }
    private void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {

    }
}
