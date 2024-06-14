using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene("Video Ovipar");
    }
    public void ChangeToSceneToFish(string sceneName)
    {
        SceneManager.LoadScene("Fish");
    }
}

