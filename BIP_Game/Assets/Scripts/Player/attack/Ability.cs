using System;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public Sprite icon;
    public float cooldown;

    [NonSerialized]
    private float lastUseTime = -999f;

    public bool CanUse()
    {
        return Time.time >= lastUseTime + cooldown;
    }

    public bool TryActivate(GameObject user)
    {
        if (CanUse())
        {
            Activate(user);
            lastUseTime = Time.time;
            return true;
        }
        else return false;
    }

    public abstract void Activate(GameObject user);
}
