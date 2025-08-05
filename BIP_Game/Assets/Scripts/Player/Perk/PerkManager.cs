using UnityEngine;
using System.Collections.Generic;

public class PerkManager : MonoBehaviour
{
    public List<Perk> allPerks; // добавь сюда все возможные перки в инспекторе

    public List<Perk> GetRandomPerks(int count)
{
    List<Perk> available = new List<Perk>();

    foreach (var perk in allPerks)
    {
        if (!Expirience.playersPerks.Contains(perk))
        {
            available.Add(perk);
        }
    }

    List<Perk> randomPerks = new List<Perk>();
    
    for (int i = 0; i < count && available.Count > 0; i++)
    {
        int index = Random.Range(0, available.Count);
        randomPerks.Add(available[index]);
        available.RemoveAt(index);
    }

    return randomPerks;
}

}
