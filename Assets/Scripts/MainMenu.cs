using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private PauseMenu pauseMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        pauseMenu.Pause();
    }

    public void QuitGame()
    {
        Debug.Log("Goodbye");
        Application.Quit();
    }
}