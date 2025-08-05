using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Image volumeImage;              // Assign the VolumeImage UI object
    public Sprite[] volumeSprites;        
    private int currentVolumeLevel;

    void Start()
    {
        // Optionally load saved volume
        currentVolumeLevel = PlayerPrefs.GetInt("VolumeLevel", 7); 
        UpdateVolumeUI();
    }

    void UpdateVolumeUI()
    {
        currentVolumeLevel = Mathf.Clamp(currentVolumeLevel, 0, volumeSprites.Length - 1);

        volumeImage.sprite = volumeSprites[currentVolumeLevel];

        AudioListener.volume = currentVolumeLevel / (float)(volumeSprites.Length - 1);
    }

    public void IncreaseVolume()
    {
        if (currentVolumeLevel < volumeSprites.Length - 1)
        {
            currentVolumeLevel++;
            UpdateVolumeUI();
            PlayerPrefs.SetInt("VolumeLevel", currentVolumeLevel);
        }
    }

    public void DecreaseVolume()
    {
        if (currentVolumeLevel > 0)
        {
            currentVolumeLevel--;
            UpdateVolumeUI();
            PlayerPrefs.SetInt("VolumeLevel", currentVolumeLevel);
        }
    }
    private void UpdateIcon()
    {
        volumeImage.sprite = volumeSprites[currentVolumeLevel];
        AudioListener.volume = currentVolumeLevel / 7f;

    }
}
