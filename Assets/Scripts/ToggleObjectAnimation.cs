using UnityEngine;

public class ToggleObjectAnimation : MonoBehaviour
{
    public Animator objectAnimator;

    public string[] availableAnimations;

    private int currentAnimationIndex = 0;

    public void Start()
    {
        if (objectAnimator == null)
        {
            Debug.LogError("Object Animator is not assigned!");
            return;
        }
    }

    public void CycleNextAnimation()
    {
        if (availableAnimations.Length == 0)
        {
            Debug.LogWarning("No available animations!");
            return;
        }

        currentAnimationIndex = (currentAnimationIndex + 1) % availableAnimations.Length;

        string nextAnimation = availableAnimations[currentAnimationIndex];

        objectAnimator.Play(nextAnimation);
    }
}
