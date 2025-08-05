using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;



public class Expirience : MonoBehaviour
{
   public static List<Perk> playersPerks = new List<Perk>();

    // Health UI
    [SerializeField]
    public Sprite[] expSprites;
    [SerializeField]
    public Image expImage;
    public PerkDisplay perkDisplay;
    public PerkManager perkManager;

    List<Perk> Available;
    
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

        
        //print(EXP);
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

        perkDisplay.ShowAvailablePerks(perkManager.GetRandomPerks(3));

        Debug.Log("Level Up! New level: " + level);
    }

}
