using UnityEngine;
using System.Collections.Generic;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();
    public KeyCode[] abilityKeys = { KeyCode.Q, KeyCode.E, KeyCode.R };

    void Update()
    {
        for (int i = 0; i < abilities.Count && i < abilityKeys.Length; i++)
        {
            if (Input.GetKeyDown(abilityKeys[i]))
            {
                abilities[i].TryActivate(gameObject);
            }
        }
    }

    public void AddAbility(Ability ability)
    {
        if (!abilities.Contains(ability))
        {
            abilities.Add(ability);
            Debug.Log("Новая способность добавлена: " + ability.abilityName);
        }
    }
}
