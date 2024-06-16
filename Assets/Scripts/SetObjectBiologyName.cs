using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;

public class SetObjectBiologyName : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    void Start()
    {
        ObserverBehaviour observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnObserverStatusChanged;
        }
    }

    void OnDestroy()
    {
        ObserverBehaviour observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged -= OnObserverStatusChanged;
        }
    }

    void OnObserverStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        string targetName = behaviour.TargetName;
        if (targetStatus.Status == Status.TRACKED)
        {
            UpdateUIText(targetName);
        }
        else
        {
            UpdateUIText("OBJECT NOT DETECTED!");
        }
    }

    void UpdateUIText(string targetName)
    {
        if (uiText != null)
        {
            switch (targetName)
            {
                case "elephant":
                    uiText.text = "(Elephantidae)";
                    break;
                case "wolf":
                    uiText.text = "(Canis Lupus)";
                    break;
                case "crocodile":
                    uiText.text = "(Crocodylidae)";
                    break;
                case "shark":
                    uiText.text = "(Selachimorpha)";
                    break;
                case "angelfish":
                    uiText.text = "(Pomacanthus Imperator)";
                    break;
                case "snake":
                    uiText.text = "(Serpentes)";
                    break;
                default:
                    uiText.text = "OBJECT NOT DETECTED!";
                    break;
            }
        }
        else
        {
            Debug.LogError("UI Text reference is missing!");
        }
    }
}
