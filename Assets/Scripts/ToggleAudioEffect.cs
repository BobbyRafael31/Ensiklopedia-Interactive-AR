using UnityEngine;

public class ToggleAudioEffect : MonoBehaviour
{
    public AudioSource hapticAudioTrigger;

    private void Awake()
    {
        hapticAudioTrigger = GetComponent<AudioSource>();
    }

    public void setHapticAudio()
    {
        if(hapticAudioTrigger != null)
        {
            hapticAudioTrigger.Play();
        }
    }


}
