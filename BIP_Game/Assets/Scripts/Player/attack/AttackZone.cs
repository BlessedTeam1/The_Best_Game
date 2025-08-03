using UnityEngine;

public class AttackZoneDamage : MonoBehaviour
{
    public int damage = 50;
    public float activeTime = 2f;

    private Animator animator;
    private Collider2D col;

    void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        col.enabled = false;
    }

    public void PerformAttack()
    {
        col.enabled = true;
        animator.Play("GreenAttack");

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
