using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 20;                  // Сколько урона наносит
    public float attackCooldown = 0.5f;      // Задержка между атаками
    private float lastAttackTime;

    private void OnCollisionStay2D(Collision2D other)
    {
        // Проверяем, можно ли атаковать (по таймеру)
        if (Time.time - lastAttackTime < attackCooldown)
            return;

        // Проверяем, есть ли у объекта компонент здоровья
        Health targetHealth = other.gameObject.GetComponent<Health>();
        if (targetHealth != null)
        {
            // Атакуем!
            targetHealth.TakeDamage(damage);
            Debug.Log("Враг атакует: " + other.gameObject.name + " на " + damage + " урона");
            lastAttackTime = Time.time;
        }
    }
}
