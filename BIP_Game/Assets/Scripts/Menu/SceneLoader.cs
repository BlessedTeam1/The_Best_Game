using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is empty on " + gameObject.name);
        }
    }
    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
