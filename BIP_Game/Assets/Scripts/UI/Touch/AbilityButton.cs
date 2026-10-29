using UnityEngine;
using UnityEngine.EventSystems;

// On-screen ability button. Put this on a UI Image; it fires on press (not release), like a key.
public class AbilityButton : MonoBehaviour, IPointerDownHandler
{
    public int abilityIndex = 0; // 0 = first ability (Space on keyboard)

    // turn off when this sits on UI that PC needs too (like the cooldown icon); on PC it then also works with a mouse click
    public bool hideOnDesktop = true;

    private AbilityManager abilityManager;

    void Awake()
    {
        // touch controls are only needed on phones (and in the Editor for testing)
        if (hideOnDesktop && !Application.isMobilePlatform && !Application.isEditor)
            gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // found on first press, since the player may be spawned after the UI
        if (abilityManager == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                abilityManager = player.GetComponentInChildren<AbilityManager>(); // may sit on a child object
        }

        if (abilityManager != null)
            abilityManager.ActivateAbility(abilityIndex);
    }
}
