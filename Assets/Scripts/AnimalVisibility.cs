using UnityEngine;

public class AnimalVisibility : MonoBehaviour
{
    public GameObject objCanvas;

    public GameObject animal;

    public void HideCanvas()
    {
        objCanvas.SetActive(false);
    }

    public void ShowCanvas()
    {
        objCanvas.SetActive(true);
    }

    public void HideAnimal()
    {
        animal.SetActive(false);
    }

    public void ShowAnimal()
    {
        animal.SetActive(true);
    }
}
