using System;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public Sprite icon;
    public float cooldown = 1f;

    [NonSerialized]
    private float lastUseTime = -999f;

    public bool CanUse()
    {
        Debug.Log($"{Time.time} >= {lastUseTime} + {cooldown}");
        return Time.time >= lastUseTime + cooldown;
    }

    public void TryActivate(GameObject user)
    {
        if (CanUse())
        {
            Debug.Log("BEBRA");
            Activate(user);
            lastUseTime = Time.time;
        }
    }

    public abstract void Activate(GameObject user);
}
