using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Floating on-screen joystick: appears where the finger touches, disappears on release.
// Put this on an invisible UI Image covering the touch area (e.g. the left half of the screen).
// Its child "background" is the joystick circle, with the handle as the background's child.
public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform background;
    public RectTransform handle;
    public float handleRange = 1f;  // how far the handle can move, relative to the background radius
    public float deadZone = 0.1f;   // ignore tiny movements near the center
    public bool showAtStart = true; // show the joystick where it's placed in the editor until the first touch ends, as a hint

    // -1..1 on each axis; (0,0) when not touched
    public Vector2 Direction { get; private set; }

    private RectTransform touchArea;
    private Canvas canvas;
    private Graphic touchAreaGraphic;
    private int activePointerId = int.MinValue; // the finger controlling the joystick; others are ignored

    void Awake()
    {
        touchArea = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        touchAreaGraphic = GetComponent<Graphic>();
        background.gameObject.SetActive(showAtStart); // hidden again by the first release, like after any touch

        // touch controls are only needed on phones (and in the Editor for testing)
        if (!Application.isMobilePlatform && !Application.isEditor)
            gameObject.SetActive(false);
    }

    void Update()
    {
        // game frozen (perk choice or pause menu): let touches through to the menu buttons underneath
        bool frozen = Time.timeScale == 0f;
        touchAreaGraphic.raycastTarget = !frozen;

        if (frozen && activePointerId != int.MinValue)
            Release();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (activePointerId != int.MinValue)
            return; // another finger is already using the joystick

        activePointerId = eventData.pointerId;

        // move the joystick under the finger, so this spot is the (0,0) center
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            touchArea, eventData.position, CanvasCamera(), out Vector3 worldPoint);
        background.position = worldPoint;
        handle.anchoredPosition = Vector2.zero;
        background.gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, eventData.position, CanvasCamera(), out Vector2 localPoint);

        Vector2 radius = background.sizeDelta / 2f;
        Vector2 input = new Vector2(localPoint.x / radius.x, localPoint.y / radius.y);
        input = Vector2.ClampMagnitude(input, 1f);

        Direction = input.magnitude < deadZone ? Vector2.zero : input;
        handle.anchoredPosition = input * radius * handleRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.pointerId != activePointerId)
            return;

        Release();
    }

    private void Release()
    {
        activePointerId = int.MinValue;
        Direction = Vector2.zero;
        background.gameObject.SetActive(false);
    }

    private Camera CanvasCamera()
    {
        return canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera;
    }
}
