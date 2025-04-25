using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.IMGUI.Controls;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI questionText;
    public Button[] optionButtons;

    public QuizQuestions[] questions;
    private int currentQuestionIndex = 0;

    public int score = 0;
    public string level = "";

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        QuizQuestions q = questions[currentQuestionIndex];

        titleText.text = $"Question {currentQuestionIndex + 1}";
        questionText.text = q.question;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.options[i];

            int index = i; // Important: local copy for the lambda
            optionButtons[i].onClick.RemoveAllListeners(); // Clear old listeners
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(index));
        }
    }

    void OnOptionSelected(int selectedIndex)
    {
        QuizQuestions q = questions[currentQuestionIndex];

        if (selectedIndex == q.correctAnswerIndex)
        {
            Debug.Log("Correct!");
            score++;
            // Do correct logic (e.g., score++, feedback)
        }
        else
        {
            Debug.Log("Wrong!");
        }

        // Move to next question or finish
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
            ShowQuestion();
        else
        {
            Debug.Log("Quiz Complete! Your score out of 9 is " + score);
            if (score < 2)
                level = "beginner";
            else if (score < 5)
                level = "intermediate";
            else if (score < 7)
                level = "advanced";
            else if (score <= 9)
                level = "fluent";

            PlayerDataManager.Instance.englishLevel = level;
            SceneManager.LoadScene("InsideBar");
        }
            
    }
}
