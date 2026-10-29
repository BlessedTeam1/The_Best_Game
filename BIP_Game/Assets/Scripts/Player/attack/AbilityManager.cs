using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    public GameObject spriteObject;
    public KeyCode[] abilityKeys = { KeyCode.Space, KeyCode.E, KeyCode.R };

    public List<PerfromCoolDown> CoolDown;


    void Update()
    {
        for (int i = 0; i < abilities.Count && i < abilityKeys.Length; i++)
        {
            if (Input.GetKeyDown(abilityKeys[i]))
                ActivateAbility(i);
        }
    }

    // called by the keyboard above and by on-screen AbilityButtons
    public void ActivateAbility(int i)
    {
        if (i < 0 || i >= abilities.Count || PauseMenu.IsPaused)
            return;

        if (abilities[i].TryActivate(gameObject))
        {
            if (spriteObject != null)
            {

                spriteObject.SetActive(!spriteObject.activeSelf);
                StartCoroutine(HideAfterDelay(0.08f));
            }

            // the icon is optional: an ability without one still works, just with no cooldown shown
            if (i < CoolDown.Count && CoolDown[i] != null)
                StartCoroutine(CoolDown[i].PerformCoolDown(abilities[i].cooldown));


        }
    }


    public void AddAbility(Ability ability)
    {
        if (!abilities.Contains(ability))
        {
            abilities.Add(ability);
        }
    }
    
    public IEnumerator HideAfterDelay(float coolDown)
    {
        
        yield return new WaitForSeconds(coolDown);
        spriteObject.SetActive(false);
    }
}
