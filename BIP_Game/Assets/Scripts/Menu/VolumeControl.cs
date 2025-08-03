using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Image volumeImage;              // Assign the VolumeImage UI object
    public Sprite[] volumeSprites;        
    private int currentVolumeLevel = 2;   // Start at medium (0 to 4)

    public void IncreaseVolume()
    {
        if (currentVolumeLevel < volumeSprites.Length - 1)
        {
            currentVolumeLevel++;
            UpdateIcon();
        }
    }

    public void DecreaseVolume()
    {
        if (currentVolumeLevel > 0)
        {
            currentVolumeLevel--;
            UpdateIcon();
        }
    }

    private void UpdateIcon()
    {
        volumeImage.sprite = volumeSprites[currentVolumeLevel];
        AudioListener.volume = currentVolumeLevel / 7f;

    }
}
