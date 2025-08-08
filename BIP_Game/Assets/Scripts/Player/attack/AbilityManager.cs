using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    public GameObject spriteObject;
    public KeyCode[] abilityKeys = { KeyCode.Q, KeyCode.E, KeyCode.R };

    public List<PerfromCoolDown> CoolDown;


    void Update()
    {
        for (int i = 0; i < abilities.Count && i < abilityKeys.Length; i++)
        {
            if (Input.GetKeyDown(abilityKeys[i]))
            {
                if (abilities[i].TryActivate(gameObject))
                {
                    if (spriteObject != null)
                    {

                        spriteObject.SetActive(!spriteObject.activeSelf);
                        StartCoroutine(HideAfterDelay(0.08f));
                    }

                    StartCoroutine(CoolDown[i].PerformCoolDown(abilities[i].cooldown));
                    

                }
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
    
    public IEnumerator HideAfterDelay(float coolDown)
    {
        
        yield return new WaitForSeconds(coolDown);
        spriteObject.SetActive(false);
    }
}
