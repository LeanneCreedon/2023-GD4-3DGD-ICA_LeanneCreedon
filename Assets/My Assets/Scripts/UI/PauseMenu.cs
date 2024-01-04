using UnityEngine;

/// <summary>
/// Tutorial Followed: https://www.youtube.com/watch?v=G1AQxNAQV8g
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {

    }

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
