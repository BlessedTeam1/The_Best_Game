using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    // set when the player dies, so the restart screen knows which level to reload
    public static string lastLevel = "";

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            Time.timeScale = 1f; // may be called from the pause menu; the next scene must not start frozen
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is empty on " + gameObject.name);
        }
    }
    // for the restart screen's button; falls back to sceneToLoad if no level was played yet (e.g. testing this scene directly)
    public void RestartLastLevel()
    {
        string level = string.IsNullOrEmpty(lastLevel) ? sceneToLoad : lastLevel;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(level);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
