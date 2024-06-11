using UnityEngine;

public class AnimalAudio : MonoBehaviour
{
    public AudioSource _animalSound;

    private void Start()
    {
        _animalSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Untuk Input Mouse (PC)
        if (Input.GetMouseButtonDown(0))
        {
            CheckForHitRaycast(Input.mousePosition);
        }

        //Untuk Input Touch (Android)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CheckForHitRaycast(touch.position);
            }
        }
    }

    void CheckForHitRaycast(Vector3 inputPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                PlaySound();
                Debug.Log("Sound is Playing");
            }
        }
    }

    void PlaySound()
    {
        if(_animalSound != null && !_animalSound.isPlaying)
        {
            _animalSound.Play();
        }
    }
}
