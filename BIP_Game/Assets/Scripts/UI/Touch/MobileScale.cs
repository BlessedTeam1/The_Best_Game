using UnityEngine;

// Makes a UI element bigger on phones (e.g. ability icons, which need to be thumb-sized), and can move it.
// Scales around the pivot, so set the pivot to the corner the element is anchored to.
public class MobileScale : MonoBehaviour
{
    public float mobileScale = 5f;
    public Vector2 mobileOffset = new Vector2(-300f, 300f); // in canvas units; negative x = left, positive y = up

    void Awake()
    {
        // also true in the Editor's Device Simulator, so it can be previewed there
        if (Application.isMobilePlatform)
        {
            transform.localScale *= mobileScale;

            if (transform is RectTransform rect)
                rect.anchoredPosition += mobileOffset;
        }
    }
}
