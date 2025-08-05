using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;

    [Header("Obstacle Avoidance Settings")]
    public float obstacleCheckCircleRadius = 0.5f;
    public float obstacleCheckDistance = 1.5f;
    public LayerMask obstacleLayerMask;
    public float obstacleAvoidanceCooldown = 0.5f;

    private Vector2 targetDirection;
    private Vector2 obstacleAvoidanceDirection;
    private RaycastHit2D[] obstacleHits;
    private float obstacleAvoidanceTimer;

    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        obstacleHits = new RaycastHit2D[10];
        targetDirection = Vector2.up;
    }

    void Update()
    {
        if (player == null)
            return;

        // Update movement direction toward player
        Vector2 desiredDirection = (player.position - transform.position).normalized;

        // Handle obstacle detection and avoidance
        HandleObstacles(ref desiredDirection);

        // Move in the final direction
        Move(desiredDirection);
    }

    void HandleObstacles(ref Vector2 desiredDirection)
    {
        obstacleAvoidanceTimer -= Time.deltaTime;

        var contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(obstacleLayerMask);
        contactFilter.useTriggers = false;

        int hitCount = Physics2D.CircleCast(
            transform.position,
            obstacleCheckCircleRadius,
            desiredDirection,
            contactFilter,
            obstacleHits,
            obstacleCheckDistance);

        for (int i = 0; i < hitCount; i++)
        {
            var hit = obstacleHits[i];
            if (hit.collider.gameObject == gameObject)
                continue;

            if (obstacleAvoidanceTimer <= 0)
            {
                // Use the obstacle surface normal to steer away
                obstacleAvoidanceDirection = hit.normal;
                obstacleAvoidanceTimer = obstacleAvoidanceCooldown;
            }

            desiredDirection = (desiredDirection + obstacleAvoidanceDirection).normalized;
            break;
        }
    }

    void Move(Vector2 direction)
    {
        rb.AddForce(direction * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
