using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadARMenu()
    {
        LoadScene("ARCamera");
    }

    public void LoadMainMenu()
    {
        LoadScene("EnsiklopediaMenu");
    }

    public void LoadElephantDetail()
    {
        LoadScene("Elephant");
    }

    public void LoadBirdDetail()
    {
        LoadScene("Bird");
    }

    public void LoadRhinoDetail()
    {
        LoadScene("Rhino");
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void LoadQuestionMenu()
    {
        LoadScene("Question");
    }

    public void LoadEvaluation()
    {
        LoadScene("Evaluation");
    }
}
