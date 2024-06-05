using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationManager : MonoBehaviour
{
    public TextMeshProUGUI evaluationText;
    public Button yesButton;
    public Button noButton;
    public QuizData questionData;
    private List<Question> questions;
    private int currentQuestionIndex = 0;

    void Start()
    {
        yesButton.onClick.AddListener(() => CheckAnswer(true));
        noButton.onClick.AddListener(() => CheckAnswer(false));
        LoadQuestions();
        UpdateQuestion();
    }

    void LoadQuestions()
    {
        if (questionData != null)
        {
            questions = new List<Question>(questionData.questions);
        }
        else
        {
            Debug.LogError("Tidak ada pertanyaan yang ditemukan!");
        }
    }

    void UpdateQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            evaluationText.text = questions[currentQuestionIndex].question;
        }
        else
        {
            evaluationText.text = "Pertanyaan Telah Selesai!";
            yesButton.interactable = false;
            noButton.interactable = false;
        }
    }

    void CheckAnswer(bool answer)
    {
        if (questions[currentQuestionIndex].isTrue == answer)
        {
            RatingManager.AddScore(1);
        }

        currentQuestionIndex++;
        UpdateQuestion();
    }
}
