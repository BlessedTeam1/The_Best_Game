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
        image.fillAmount = 1;
        while (image.fillAmount > 0)
        {
            yield return new WaitForSeconds(0.05f);
            image.fillAmount -= 0.025f;
        }
    }
}
