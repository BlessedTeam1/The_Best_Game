using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + "Enemy hp: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Здесь можно добавить анимацию смерти
         LootDropper dropper = GetComponent<LootDropper>();
    if (dropper != null)
    {
        dropper.DropLoot();
    }
        Destroy(gameObject);
    }
}
