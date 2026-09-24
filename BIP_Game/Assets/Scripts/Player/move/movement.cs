using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    private Vector2 moveDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        float moveY = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;

        moveDir = new Vector2(moveX, moveY).normalized;

        // flip only when moving horizontally, so the player keeps facing the last direction
        if (moveX != 0)
            sr.flipX = moveX < 0;

    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

}
