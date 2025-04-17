using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorial : MonoBehaviour
{
    public GameObject tutorialUI;
    public GameObject interactHint;
    public TMP_Text tutorialText;    
    private bool inRange;

    public FreezePlayer freezePlayerScript;

    public void Start()
    {
        // Hide the tutorial UI at the start
        tutorialUI.SetActive(false);
    }

    private void Update()
    {
        if (inRange)
        {
            // Check if the player presses the "E" key
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Show the tutorial
                ShowTutorial();
            }
        }
    }

    public void ShowTutorial()
    {
        freezePlayerScript.Freeze(); // Freeze the player movement
        // Show the tutorial UI
        tutorialUI.SetActive(true);
        // Set the tutorial text
        tutorialText.text = "Welcome! Before I let you in, let's see how much you know!";
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger
        if (other.CompareTag("Player"))
        {
            inRange = true;
            interactHint.SetActive(true); // Show the interact hint
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            interactHint.SetActive(false); // Hide the interact hint
        }
    }

}
