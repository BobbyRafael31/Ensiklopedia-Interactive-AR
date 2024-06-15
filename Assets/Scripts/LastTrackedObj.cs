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
                case "bird":
                    SceneManager.LoadScene("Bird");
                    break;
                case "elephant":
                    sceneLoader.StartCoroutine(sceneLoader.LoadScene("Elephant"));
                    break;
                case "rhino":
                    SceneManager.LoadScene("Rhino");
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
