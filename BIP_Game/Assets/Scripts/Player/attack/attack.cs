using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public float attackRange = 3f;        // Радиус атаки
    public float attackCooldown = 1.5f;   // Время между атаками
    public int damage = 10;               // Урон

    private float lastAttackTime = 0f;

    void Update()
    {
        GameObject target = FindClosestEnemy();

        if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.transform.position);
            if (distance <= attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                Attack(target);
                lastAttackTime = Time.time;
            }
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }

    void Attack(GameObject target)
    {
        Debug.Log("Атака по " + target.name);
        
        EnemyHealth hp = target.GetComponent<EnemyHealth>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }
}
