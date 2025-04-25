using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTutorial : MonoBehaviour
{
    public GameObject tutorialUI;
    public GameObject interactHint;
    public TMP_Text tutorialText;    
    private bool inRange;
    public bool waitForClick = false; // Flag to check if waiting for click

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

        if (waitForClick && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("DiagnosticTest");
    }

    public void ShowTutorial()
    {
        freezePlayerScript.Freeze(); // Freeze the player movement
        interactHint.SetActive(false); // Hide the interact hint
        // Show the tutorial UI
        tutorialUI.SetActive(true);
        // Set the tutorial text
        tutorialText.text = "Welcome! Before I let you in, let's see how much you know!";

        waitForClick = true; // Set the flag to true

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
