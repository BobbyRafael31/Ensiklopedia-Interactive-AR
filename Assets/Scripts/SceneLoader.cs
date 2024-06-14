using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadARMenu()
    {
        StartCoroutine(LoadScene("ARCamera"));
    }

    public void LoadEnsiklopediaMenu()
    {
        StartCoroutine(LoadScene("EnsiklopediaMenu"));
    }

    public void LoadDetailFlora()
    {
        StartCoroutine(LoadScene("DetailFlora"));
    }

    public void LoadDetailFauna()
    {
        StartCoroutine(LoadScene("DetailFauna"));
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
    public void LoadAngelFishDetail()
    {
        LoadScene("Fish");
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
