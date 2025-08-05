using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Circle Slash")]
public class CircleSlashAbility : Ability
{
    public GameObject attackZonePrefab;

    public override void Activate(GameObject user)
    {
        GameObject attack = Instantiate(attackZonePrefab, user.transform.position, Quaternion.identity);
        // Можно задать владельца или передать урон
    }
}
