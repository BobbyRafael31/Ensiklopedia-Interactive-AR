using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RatingManager : MonoBehaviour
{

    public TextMeshProUGUI ratingText;
    private static int totalRating = 0;

    void Start()
    {
        UpdateRatingUI();
    }

    public static void AddScore(int rating)
    {
        totalRating += rating;
        UpdateAllRatingUI();
    }

    static void UpdateAllRatingUI()
    {
        RatingManager[] ratingManagers = FindObjectsOfType<RatingManager>();
        foreach (RatingManager ratingManager in ratingManagers)
        {
            ratingManager.UpdateRatingUI();
        }
    }

    void UpdateRatingUI()
    {
        ratingText.text = totalRating.ToString();
    }
}
