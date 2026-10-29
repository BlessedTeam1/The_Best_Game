using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PerfromCoolDown : MonoBehaviour
{
    private Image image;
    public float CoolDown = 1f;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public IEnumerator PerformCoolDown(float CoolDownTime)
    {
        // empties over exactly CoolDownTime seconds of game time, same clock as Ability's cooldown
        float remaining = CoolDownTime;
        while (remaining > 0f)
        {
            image.fillAmount = remaining / CoolDownTime;
            yield return null;
            remaining -= Time.deltaTime;
        }
        image.fillAmount = 0f;
    }
}
