using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorial : MonoBehaviour
{
    public GameObject tutorialUI;
    public TextMeshPro tutorialText;

    public void Start()
    {
        // Hide the tutorial UI at the start
        tutorialUI.SetActive(true);
    }

}
