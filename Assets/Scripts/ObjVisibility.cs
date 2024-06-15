using UnityEngine;

public class ObjVisibility : MonoBehaviour
{
    public GameObject obj;

    public void ActiveButton()
    {
        obj.SetActive(true);
    }

    public void HideButton()
    {
        obj.SetActive(false);
    }

}
