// UpgradeBase.cs
using UnityEngine;

public abstract class UpgradeBase : ScriptableObject
{
    public string upgradeName;
    [TextArea] public string description;

    // Этот метод будет вызываться, когда игрок выберет этот апгрейд.
    public abstract void Apply(GameObject target);
}
