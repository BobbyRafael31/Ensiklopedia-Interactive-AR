using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public IEnumerator LoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void LoadStartMenu()
    {
        StartCoroutine(LoadScene("StartMenu"));
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

    public void LoadListFauna()
    {
        StartCoroutine(LoadScene("ListFauna"));
    }

    public void LoadListFlora()
    {
        StartCoroutine(LoadScene("ListFlora"));
    }

    public void LoadElephantDetail()
    {
        StartCoroutine(LoadScene("Elephant"));
    }

    public void LoadWolfDetail()
    {
        StartCoroutine(LoadScene("Wolf"));
    }

    public void LoadCrocodileDetail()
    {
        StartCoroutine(LoadScene("Crocodile"));
    }

    public void LoadSharkDetail()
    {
        StartCoroutine(LoadScene("Shark"));
    }

    public void LoadAngelFishDetail()
    {
        StartCoroutine(LoadScene("AngelFish"));
    }

    public void LoadSnakeDetail()
    {
        StartCoroutine(LoadScene("Snake"));
    }

    public void LoadRoseDetail()
    {
        StartCoroutine(LoadScene("Rose"));
    }

    public void LoadSunflowerDetail()
    {
        StartCoroutine(LoadScene("Sunflower"));
    }

    public void LoadPalmDetail()
    {
        StartCoroutine(LoadScene("Palm"));
    }

    public void LoadBananaDetail()
    {
        StartCoroutine(LoadScene("Banana"));
    }

    public void LoadViviparVideo()
    {
        StartCoroutine(LoadScene("ViviparVideo"));
    }

    public void LoadOviparVideo()
    {
        StartCoroutine(LoadScene("OviparVideo"));
    }

    public void LoadOvoviviparVideo()
    {
        StartCoroutine(LoadScene("OvoviviparVideo"));
    }

    public void LoadDikotilVideo()
    {
        StartCoroutine(LoadScene("DikotilVideo"));
    }

    public void LoadMonokotilVideo()
    {
        StartCoroutine(LoadScene("MonokotilVideo"));
    }

    public void LoadQuestionMenu()
    {
        StartCoroutine(LoadScene("Question"));
    }

    public void ExitApp()
    {
        Application.Quit();
    }

}
