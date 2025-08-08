using UnityEngine;
using System.Collections;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public Animator animator;
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + "Enemy hp: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void GetFire()
    {
        print("BUTT");
        animator.Play("Fire");
    }
    void Die()
{
    animator.Play("Death");

    LootDropper dropper = GetComponent<LootDropper>();
    if (dropper != null)
    {
        dropper.DropLoot();
    }

    var col = GetComponent<Collider2D>();
    if (col != null) col.enabled = false;

    var rb = GetComponent<Rigidbody2D>();
    if (rb != null) rb.simulated = false;

    this.enabled = false;

    StartCoroutine(DieAfterAnimation());
}
IEnumerator DieAfterAnimation()
{
    float deathAnimLength = animator.GetCurrentAnimatorStateInfo(0).length;
    yield return new WaitForSeconds(deathAnimLength);
    Destroy(gameObject);
}

}
