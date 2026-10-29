using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public int healAmount = 25; // Количество восстановления

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
            }

            Destroy(gameObject); // Удалить зелье
        }
    }
}
