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
        switch (perkType)
        {
            case PerkType.Damage:
                var atk = player.GetComponentInChildren<AttackZoneDamage>();
                if (atk != null)
                    atk.damage += (int)value;
                break;

            case PerkType.Speed:
                // value is a percentage: 20 = +20% move speed
                var move = player.GetComponent<movement>();
                if (move != null)
                    move.moveSpeed *= 1f + value / 100f;
                break;

            case PerkType.HP:
                // value is flat: 25 = +25 max health
                var health = player.GetComponent<Health>();
                if (health != null)
                    health.IncreaseMaxHealth((int)value);
                break;
        }
    }
}


