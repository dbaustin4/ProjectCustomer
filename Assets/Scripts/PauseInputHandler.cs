using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInputHandler : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;

    private void Update()
    {
        // Check for the "P" key press to toggle the pause menu.
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pauseMenu.isPaused)
            {
                pauseMenu.Pause();
            }
            else
            {
                pauseMenu.Resume();
            }
        }
    }
}
