using UnityEngine;

public class AnimalVisibility : MonoBehaviour
{
    public GameObject animal;
    public void HideAnimal()
    {
        animal.SetActive(false);
    }

    public void ShowAnimal()
    {
        animal.SetActive(true);
    }
}
