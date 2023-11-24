using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class SpacerPoOsiedluButton : MonoBehaviour
{
    public Camera MainCamera;
    public Camera PlayerCamera;
    public Button WalkButton;

    private void Start()
    {
        PlayerCamera.enabled = false;
        WalkButton.onClick.AddListener(SwitchCamera);
    }

    void SwitchCamera()
    {
        MainCamera.enabled = !MainCamera.enabled;
        PlayerCamera.enabled = !PlayerCamera.enabled;
    }

}
