using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;

    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.AddForce((Vector3)(direction * moveSpeed * Time.deltaTime), ForceMode2D.Impulse);
        }
    }
}
