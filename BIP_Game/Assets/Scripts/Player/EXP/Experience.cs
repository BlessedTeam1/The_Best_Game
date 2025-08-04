using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Expirience : MonoBehaviour
{
    // Health UI
    [SerializeField]
    public Sprite[] expSprites;
    [SerializeField]
    public Image expImage;

    public int maxExp = 8;
    static public int EXP = 0;
    private int level = 1;

    public TMP_Text levelText;      // ← Assign a UI Text element


    private void Start()
    {
        levelText.text = "1";
    }

    void Update()
    {
        print(EXP);
        UpdateExp();
        if (EXP >= maxExp)
        {
            LevelUp();
        }
    }
    void UpdateExp()
    {
        float expPercent = Mathf.Clamp01((float)EXP / maxExp);
        int spriteIndex = Mathf.RoundToInt(expPercent * (expSprites.Length - 1));
        spriteIndex = Mathf.Clamp(spriteIndex, 0, expSprites.Length - 1);

        expImage.sprite = expSprites[spriteIndex];
    }
    void LevelUp()
    {
        EXP -= maxExp;  // Carry over leftover EXP
        level++;
        levelText.text = level.ToString();

        Debug.Log("Level Up! New level: " + level);
    }
}
