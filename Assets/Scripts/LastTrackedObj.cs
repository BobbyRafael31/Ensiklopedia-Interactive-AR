using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class LastTrackedObj : MonoBehaviour
{
    public string lastTrackedObjectName;
    private SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        ObserverBehaviour observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        else
        {
            Debug.LogError("ObserverBehaviour component not found!");
        }
    }

    void OnDestroy()
    {
        ObserverBehaviour observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        string targetName = behaviour.TargetName;
        if (targetStatus.Status == Status.TRACKED)
        {
            lastTrackedObjectName = targetName;
        }

    }

    public void LoadDetailScene()
    {
        if (!string.IsNullOrEmpty(lastTrackedObjectName))
        {
            switch (lastTrackedObjectName)
            {
                case "elephant":
                    sceneLoader.StartCoroutine(sceneLoader.LoadScene("Elephant"));
                    break;
                case "wolf":
                    sceneLoader.StartCoroutine(sceneLoader.LoadScene("Wolf"));
                    break;
                case "crocodile":
                    sceneLoader.StartCoroutine(sceneLoader.LoadScene("Crocodile"));
                    break;
                case "shark":
                    sceneLoader.StartCoroutine(sceneLoader.LoadScene("Shark"));
                    break;
                case "angelfish":
                    sceneLoader.StartCoroutine(sceneLoader.LoadScene("Angelfish"));
                    break;
                case "snake":
                    sceneLoader.StartCoroutine(sceneLoader.LoadScene("Snake"));
                    break;
                default:
                    Debug.LogWarning("No detail scene found for the tracked object: " + lastTrackedObjectName);
                    break;
            }
        }
        else
        {
            Debug.LogWarning("No object has been tracked yet.");
        }
    }
}
