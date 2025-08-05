using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public Sprite icon;
    public float cooldown = 1f;

    protected float lastUseTime = -999f;

    public bool CanUse()
    {
        return Time.time >= lastUseTime + cooldown;
    }

    public void TryActivate(GameObject user)
    {
        if (CanUse())
        {
            Activate(user);
            lastUseTime = Time.time;
        }
    }

    public abstract void Activate(GameObject user);
}
