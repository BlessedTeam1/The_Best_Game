using UnityEngine;

public class AttackZoneDamage : MonoBehaviour
{
    public int damage = 50;
    public float activeTime = 2f;

    public Animator animator;
    private Collider2D col;

    public string AttackName;

     private void Awake()
    {
        
        col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;
        else
            Debug.LogError("AttackZoneDamage: нет Collider2D на префабе!");
    }
    void Start()
    {
        
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    public void PerformAttack()
    {
        col.enabled = true;
        animator.Play(AttackName);

        // Отключим коллайдер после короткого времени
        Invoke(nameof(DisableCollider), activeTime);
    }

    private void DisableCollider()
    {
        col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth hp = other.GetComponent<EnemyHealth>();

            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
        }
    }
}
