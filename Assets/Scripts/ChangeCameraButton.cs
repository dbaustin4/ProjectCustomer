using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCameraButton : MonoBehaviour
{
    public CameraSwitch cameraSwitch;

    private void Start()
    {
        if (cameraSwitch == null)
        {
            cameraSwitch = FindObjectOfType<CameraSwitch>();
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(SwitchCameraRight);
        }
        else if (button != null)
        {
            button.onClick.AddListener(SwitchCameraLeft);
        }
    }

    public void SwitchCameraLeft()
    {
        cameraSwitch.SendMessage("SetPreviousTarget");
    }
    public void SwitchCameraRight()
    {
        cameraSwitch.SendMessage("SetNextTarget");
    }
}

