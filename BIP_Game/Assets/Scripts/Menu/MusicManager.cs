using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic1;
    public AudioClip gameMusic2;


    private AudioSource audioSource;
    public string currentTrack = "";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;

            PlayMusic(menuMusic, "menu");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("scene changed to "+ scene.name);
        // You can name scenes however you want
        if (scene.name=="Level1")
        {
            PlayMusic(gameMusic1, "game");
        }
        if (scene.name == "Level2")
        {
            PlayMusic(gameMusic2, "game");
        }
        else if (scene.name =="Menu" || scene.name == "Restart_screen")
        {
            PlayMusic(menuMusic, "menu");
        }
    }

    private void PlayMusic(AudioClip clip, string trackName)
    {
        if (currentTrack == trackName) return; // already playing this
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
        currentTrack = trackName;
        print("play music "+currentTrack);
    }
}
