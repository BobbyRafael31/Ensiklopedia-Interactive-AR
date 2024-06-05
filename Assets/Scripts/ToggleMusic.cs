using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public Texture soundOnTexture;
    public Texture soundOffTexture;
    public AudioSource musicAudioSource;

    private bool isMusicOn = true;
    private RawImage rawImage;

    void Start()
    {
        rawImage = GetComponentInChildren<RawImage>();

        rawImage.texture = soundOnTexture;
    }


    public void OnButtonClick()
    {
        isMusicOn = !isMusicOn;

        rawImage.texture = isMusicOn ? soundOnTexture : soundOffTexture;

        if (musicAudioSource != null)
        {
            if (isMusicOn)
            {
                musicAudioSource.Play();
            }
            else
            {
                musicAudioSource.Pause();
            }
        }
        else
        {
            Debug.LogWarning("Music AudioSource reference is not set!");
        }
    }
}