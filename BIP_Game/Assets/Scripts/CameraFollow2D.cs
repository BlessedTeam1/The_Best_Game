using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;          // Player transform
    public Vector2 minBounds = new Vector2(0, 0);
    public Vector2 maxBounds = new Vector2(50, 30);       
    public float smoothTime = 0.1f;   // Smoothing speed

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    private float camHalfHeight;
    private float camHalfWidth;

    void Start()
    {
        cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;
    }

    void LateUpdate()
    {
        if (!target) return;

        Vector3 targetPos = target.position;

        // Clamp camera position based on level bounds and camera size
        float clampedX = Mathf.Clamp(targetPos.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(targetPos.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 desiredPos = new Vector3(clampedX, clampedY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
    }
}
