using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Pause Game - Easy Tutorial (2023), Solo Game Dev -
/// https://www.youtube.com/watch?v=G1AQxNAQV8g
/// accessed - 04/01/2024
/// ---------------------
/// Script for handling the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
