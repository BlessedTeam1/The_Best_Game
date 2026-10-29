using UnityEngine;
using UnityEngine.SceneManagement;

// Pause menu: Esc on PC, or hook a UI Button's OnClick to TogglePause / Resume / Restart / GoToMainMenu.
// Put this on an object that stays active (e.g. the Canvas), not on the pause panel itself.
public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;          // the panel with Resume / Restart / Menu buttons, inactive by default
    public string mainMenuScene = "Menu";

    public static bool IsPaused { get; private set; }

    private float timeScaleBeforePause = 1f;

    void Awake()
    {
        IsPaused = false;
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        if (IsPaused)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        if (IsPaused)
            return;

        // remember it, so pausing during the perk choice (already 0) doesn't unfreeze it on resume
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0f;
        IsPaused = true;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        if (!IsPaused)
            return;

        Time.timeScale = timeScaleBeforePause;
        IsPaused = false;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        LeavePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        LeavePause();
        SceneManager.LoadScene(mainMenuScene);
    }

    // the next scene must not start frozen
    private void LeavePause()
    {
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void OnDestroy()
    {
        IsPaused = false;
    }
}
