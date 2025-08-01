using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeClickArea : MonoBehaviour, IPointerClickHandler
{
    public Image volumeImage;               // The UI image to click on
    public Sprite[] volumeSprites;          // Volume level icons
    private int maxVolumeLevel => volumeSprites.Length - 1;

    public void OnPointerClick(PointerEventData eventData)
    {
        RectTransform rect = volumeImage.rectTransform;

        // Convert click position to local space of the image
        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, eventData.position, eventData.pressEventCamera, out localCursor))
            return;

        // Normalize to [0, 1] across the width
        float normalizedX = Mathf.InverseLerp(-rect.rect.width / 2f, rect.rect.width / 2f, localCursor.x);

        // Decide volume level based on where user clicked
        int clickedLevel = Mathf.FloorToInt(normalizedX * (volumeSprites.Length));

        // Clamp and apply
        clickedLevel = Mathf.Clamp(clickedLevel, 0, maxVolumeLevel);

        SetVolumeLevel(clickedLevel);
    }

    private void SetVolumeLevel(int level)
    {
        volumeImage.sprite = volumeSprites[level];
        AudioListener.volume = level / (float)maxVolumeLevel;
        Debug.Log("Volume set to level: " + level);
    }
}
