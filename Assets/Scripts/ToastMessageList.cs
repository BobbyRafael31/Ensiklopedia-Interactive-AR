using UnityEngine;
using static ToastNotification;

public class ToastMessageList : MonoBehaviour
{
    public void AudioIn3DObjectMessage()
    {
        Show("Tap pada hewan 3D untuk mendengarkan suara hewan", 3, "info");
    }
}
