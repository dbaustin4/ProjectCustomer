using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    public bool isSettingsOpen = false;


    public void SettingsOpen()
    {
        settingsMenu.SetActive(true);
        isSettingsOpen = true;
    }

    public void SettingsClose()
    {
        settingsMenu.SetActive(false);
        isSettingsOpen = false;

    }
}
