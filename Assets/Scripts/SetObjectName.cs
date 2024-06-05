using UnityEngine;
using TMPro;
using Vuforia;

public class SetObjectName : MonoBehaviour
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
                case "bird":
                    uiText.text = "BURUNG";
                    break;
                case "elephant":
                    uiText.text = "GAJAH";
                    break;
                case "rhino":
                    uiText.text = "BADAK";
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
