using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerOvovivipar : MonoBehaviour
{
    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene("Video Ovovivipar");
    }
    public void ChangeToSceneToUlar(string sceneName)
    {
        SceneManager.LoadScene("Ular");
    }
}