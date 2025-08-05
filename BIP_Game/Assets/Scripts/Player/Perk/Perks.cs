using UnityEngine;

[CreateAssetMenu(fileName = "New Perk", menuName = "Perk System/Perk")]
public class Perk : ScriptableObject
{
    public string perkName;
    public string description;
    public Sprite icon;

    public Ability grantedAbility;

    public enum PerkType { None, Damage, Range, Speed, HP, Regen }
    public PerkType perkType;
    public float value;

    public void Apply(GameObject player)
    {
        // Выдаём способность
        var abilityManager = player.GetComponent<AbilityManager>();
        if (grantedAbility != null && abilityManager != null)
        {
            abilityManager.AddAbility(grantedAbility);
        }

        // Пример применения других эффектов
        if (perkType == PerkType.Damage)
        {
            var atk = player.GetComponentInChildren<AttackZoneDamage>();
            if (atk != null)
                atk.damage += (int)value;
        }
    }
}


