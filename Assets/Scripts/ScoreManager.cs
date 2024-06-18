using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private static int totalScore = 0;

    void Start()
    {
        ResetScore();
        UpdateScoreUI();
    }

    public static void AddScore(int score)
    {
        totalScore += score;
        UpdateAllScoreUI();
    }

    static void UpdateAllScoreUI()
    {
        ScoreManager[] scoreManagers = FindObjectsOfType<ScoreManager>();
        foreach (ScoreManager scoreManager in scoreManagers)
        {
            scoreManager.UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = totalScore.ToString();
    }

    void ResetScore()
    {
        totalScore = 0;
    }
}
