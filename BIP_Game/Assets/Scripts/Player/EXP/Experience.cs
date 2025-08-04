using UnityEngine;
using UnityEngine.UI;


public class Expirience : MonoBehaviour
{
    // Health UI
    [SerializeField]
    public Sprite[] expSprites;
    [SerializeField]
    public Image expImage;

    public int maxExp = 8;


    static public int EXP = 0;

    
    void Update()
    {
        print(EXP);
        UpdateExp();
    }
    void UpdateExp()
    {
        float expPercent = Mathf.Clamp01((float)EXP / maxExp);
        int spriteIndex = Mathf.RoundToInt(expPercent * (expSprites.Length - 1));
        spriteIndex = Mathf.Clamp(spriteIndex, 0, expSprites.Length - 1);

        expImage.sprite = expSprites[spriteIndex];
    }
}
