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
                case "elephant":
                    uiText.text = "GAJAH";
                    break;
                case "crocodile":
                    uiText.text = "BUAYA";
                    break;
                case "wolf":
                    uiText.text = "SERIGALA";
                    break;
                case "shark":
                    uiText.text = "HIU";
                    break;
                case "snake":
                    uiText.text = "ULAR";
                    break;
                case "angelfish":
                    uiText.text = "ANGELFISH";
                    break;
                case "rose":
                    uiText.text = "BUNGA MAWAR";
                    break;
                case "sunflower":
                    uiText.text = "BUNGA MATAHARI";
                    break;
                case "palm":
                    uiText.text = "POHON PALEM";
                    break;
                case "banana":
                    uiText.text = "POHON PISANG";
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
