using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonVibrationHandler : MonoBehaviour
{
    [SerializeField]
    private Button defaultVibrationButton;

    private void OnEnable()
    {
        defaultVibrationButton.onClick.AddListener(DefaultVibration);
    }

    private void OnDisable()
    {
        defaultVibrationButton.onClick.RemoveListener(DefaultVibration);
    }

    private void DefaultVibration()
    {
        Debug.Log("Default Vibration performed!");
        Handheld.Vibrate();
    }
}
