using UnityEngine;
using static ToastNotification;

public class ToastMessageList : MonoBehaviour
{
    public void AudioIn3DObjectMessage()
    {
        Show("Tap pada 3D Hewan untuk mendengarkan suara hewan", 3, "info");
    }
}
